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
    public async Task<IActionResult> GetAll()
    {
        var obras = _obrasService.getAll();
        return Ok(obras);
    }
}