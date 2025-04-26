
using CarTools.constructs;
using CarTools.services.implement;
using CarTools.services;
using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using CarTools;
using CarTools.Entities;
using System;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IToolService, ToolService>();

var mappingConfig = TypeAdapterConfig.GlobalSettings;
mappingConfig.Scan(Assembly.GetExecutingAssembly());

builder.Services.AddSingleton<IMapper>(new Mapper(mappingConfig));

var ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection") ??
            throw new InvalidOperationException("Connection string is not found in the configuration file");

builder.Services.AddDbContext<ApplicationDbcontext>(options =>
    options.UseSqlServer(ConnectionString));

builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapGet("/tools", async (IToolService toolService) =>
{
    var tools = await toolService.GetAllasync();
    return Results.Ok(tools);
});



app.MapGet("/tools/{id:int}", async (int id, IToolService toolService) =>
{
    var tool = await toolService.GetByIdasync(id);
    return Results.Ok(tool);
});



app.MapGet("/tools/{Name:alpha}", async (string name, IToolService toolService) =>
{
    var tools = await toolService.GetByNameAsynce(name);
    return Results.Ok(tools);
});


app.MapPost("/tools", async (ToolRequest request, IToolService toolService) =>
{
    var tool = await toolService.AddPollsasync(request);
    return Results.Created($"/tools/{tool.Id}", tool);
});

app.Run();
