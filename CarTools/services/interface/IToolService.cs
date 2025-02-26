using CarTools.constructs;
using CarTools.Entities;

namespace CarTools.services;
public interface IToolService
    {
        Task<IEnumerable<ToolResponse>> GetAllasync(CancellationToken cancellationToken = default);

         Task<ToolResponse> GetByIdasync(int id, CancellationToken cancellationToken = default);
         Task<ToolResponse> AddPollsasync(ToolRequest request, CancellationToken cancellationToken = default);   
            
         Task<IEnumerable<Tool>> GetByNameAsynce(string name, CancellationToken cancellationToken = default);

        }

