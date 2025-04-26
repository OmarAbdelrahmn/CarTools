using CarTools.constructs;
using CarTools.Entities;
using Mapster;

namespace CarTools;

public class Mapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Tool, ToolResponse>()
            .Map(dest => dest.Price, src => src.Price);

        config.NewConfig<ToolRequest, Tool>()
            .Map(dest => dest.Price, src => src.Price);
    }

}
