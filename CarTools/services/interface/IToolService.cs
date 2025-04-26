using CarTools.constructs;
using CarTools.Entities;

namespace CarTools.services;
public interface IToolService
    {
    Task<IEnumerable<ToolResponse>> GetAllasync();

    Task<ToolResponse?> GetByIdasync(int id);
    Task<ToolResponse> AddPollsasync(ToolRequest request);

    Task<IEnumerable<ToolResponse>> GetByNameAsynce(string name);

}

