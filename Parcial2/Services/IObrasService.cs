using Parcial2.ApiResponse;
using Parcial2.DTOs;
using Parcial2.Models;

namespace Parcial2.Services;

public interface IObrasService
{
    Task<List<ObrasDto>> GetObras();
    Task<AlbanilXObraDto> PostAlbanilXObra(AlbanilXObraDto albanilXObraDto);
    Task<AlbanilDto> PostAlbanil(AlbanilDto albanilDto);
    Task<List<AlbanilDto>> GetAlbaniles(Guid obraId);
}