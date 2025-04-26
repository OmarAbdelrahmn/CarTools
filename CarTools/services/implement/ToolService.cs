using CarTools.constructs;
using CarTools.Entities;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace CarTools.services.implement;

public class ToolService(ApplicationDbcontext context) : IToolService
{
    private readonly ApplicationDbcontext context = context;

    public async Task<ToolResponse> AddPollsasync(ToolRequest request)
    {
        var tool = request.Adapt<Tool>();
        await context.tools.AddAsync(tool);
        await context.SaveChangesAsync();
        return tool.Adapt<ToolResponse>();
    }

    public async Task<IEnumerable<ToolResponse>> GetAllasync() =>

        await context.tools
        .ProjectToType<ToolResponse>()
        .AsNoTracking()
        .ToListAsync();

    public async Task<ToolResponse?> GetByIdasync(int id)
    {
        var tool = await context.tools
        .Where(x => x.Id == id)
        .ProjectToType<ToolResponse>()
        .AsNoTracking()
        .FirstOrDefaultAsync();

        return tool == null ? null : tool;
    }

    public async Task<IEnumerable<ToolResponse>> GetByNameAsynce(string name) =>

        await context.tools
        .Where(x => x.Name.ToLower().Contains(name.ToLower()))
        .ProjectToType<ToolResponse>()
        .AsNoTracking()
        .ToListAsync();

}
