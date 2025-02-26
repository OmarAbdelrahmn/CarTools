using CarTools;
using CarTools.services;
using CarTools.services.implement;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddIdentityApiEndpoints<IdentityUser>().AddEntityFrameworkStores<ApplicationDbcontext>();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
//builder.Services.AddAuthentication().AddGoogle(options=>
//{
//   // IConfigurationSection section = builder.Configuration.GetSection("Authentication:google");

//    options.ClientId = builder.Configuration["Authentication:google:ClientId"]!;
//    options.ClientId = builder.Configuration["Authentication:google:ClientSecret"]!;
//  //  options.ClientSecret = section["ClientSecret"]!;
//});
builder.Services.AddScoped<IToolService, ToolService>();

var connectionString = builder.Configuration.GetConnectionString("dbstring") ??
            throw new InvalidOperationException("Connection string 'dbstring' not found.");

builder.Services.AddDbContext<ApplicationDbcontext>(options =>
    options.UseSqlServer(connectionString));
//builder.Services.AddMapsterConfig();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerUI(options => // UseSwaggerUI is called only in Development.
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });

    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapOpenApi();
}

app.MapIdentityApi<IdentityUser>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
