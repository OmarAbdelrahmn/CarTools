using CarTools.services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace CarTools.Controllers;
[Route("api/[controller]")]
[ApiController]
[EnableRateLimiting("ConcurrencyLimiter")]
public class ToolsController(IToolService tool) : ControllerBase
{
    private readonly IToolService tool = tool;

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetByid(int id, CancellationToken cancellationToken)
    {

        var tools = await tool.GetByIdasync(id, cancellationToken);

        return Ok(tools);

    }
    [HttpGet("{Name:alpha}")]
    public async Task<IActionResult> GetByName(string Name, CancellationToken cancellationToken)
    {

        var tools = await tool.GetByNameAsynce(Name, cancellationToken);

        return Ok(tools);

    }
    [HttpGet("")]
    public async Task<IActionResult> GetAll( CancellationToken cancellationToken)
    {

        var tools = await tool.GetAllasync(cancellationToken);

        return Ok(tools);

    }

}
