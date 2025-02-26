using CarTools.constructs;
using CarTools.Entities;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace CarTools.services.implement;

public class ToolService(ApplicationDbcontext context) : IToolService
{
    private readonly ApplicationDbcontext context = context;

    public Task<ToolResponse> AddPollsasync(ToolRequest request, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<ToolResponse>> GetAllasync(CancellationToken cancellationToken = default)
    {
       var Alltools = await context.tools.ToListAsync();

        return Alltools.Adapt<IEnumerable<ToolResponse>>();
    }

    public async Task<ToolResponse> GetByIdasync(int id, CancellationToken cancellationToken = default)
    {
        var tool = await context.tools.FindAsync(id);

        return tool.Adapt<ToolResponse>();
    }
    public async Task<IEnumerable<Tool>> GetByNameAsynce(string Name, CancellationToken cancellationToken = default)
    {
        var Diseases = await context.tools
                   .Where(x => x.Name.StartsWith(Name))
                   .AsNoTracking()
                   .ToListAsync(cancellationToken);

        
        return Diseases;
    }
}
