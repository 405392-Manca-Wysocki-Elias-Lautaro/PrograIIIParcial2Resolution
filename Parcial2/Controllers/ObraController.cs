using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Parcial2.ApiResponse;
using Parcial2.Context;
using Parcial2.DTOs;
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
        var obras = await _obrasService.GetObras();
        return Ok(obras);
    }

    [HttpPost("/PostAlbanilXObra")]
    public async Task<IActionResult> PostAlbanilXObra([FromBody] AlbanilXObraDto albanilXObraDto)
    {
        if (albanilXObraDto == null)
        {
            return BadRequest("Datos invalidos");
        }

        try
        {
            var result = await _obrasService.PostAlbanilXObra(albanilXObraDto);
            return Ok(result);
        }
        catch (DuplicateEntryExeption ex)
        {
            return Conflict(new { message = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Error interno del servidor", details = ex.ToString() });
        }
    }

    [HttpPost("/PostAlbanil")]
    public async Task<IActionResult> PostAlbanil([FromBody] AlbanilDto albanilDto)
    {
        if (albanilDto.Nombre.IsNullOrEmpty()
            || albanilDto.Apellido.IsNullOrEmpty()
            || albanilDto.Dni.IsNullOrEmpty())
        {
            return BadRequest("Campos incompletos");
        }

        try
        {
            var result = await _obrasService.PostAlbanil(albanilDto);
            return Ok(result);
        }
        catch (DuplicateEntryExeption ex)
        {
            return Conflict(new { message = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Error interno del servidor", details = ex.ToString() });
        }
    }

    [HttpGet("/GetAlbaniles/{obraId}")]
    public async Task<ActionResult<List<AlbanilDto>>> GetAlbaniles(Guid obraId)
    {
        var albaniles = await _obrasService.GetAlbaniles(obraId);
        return Ok(albaniles);
    }

}