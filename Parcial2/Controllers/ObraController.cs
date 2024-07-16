using Microsoft.AspNetCore.Mvc;
using Parcial2.Context;
using Parcial2.Services;

namespace Parcial2.Controllers;

[ApiController]
public class ObraController : ControllerBase
{
    private readonly IObrasService _obrasService;

    public ObraController(IObrasService obrasService)
    {
        _obrasService = obrasService;
    }

    [HttpGet("/GetObras")]
    public async Task<IActionResult> GetAllObras()
    {
        var obras = await _obrasService.GetAllObras();
        return Ok(obras);
    }

    [HttpGet("/GetAllAOX")]
    public async Task<IActionResult> GetAllAOX()
    {
        var albanilesXObras = await _obrasService.GetAllAXO();
        return Ok(albanilesXObras);
    }

}