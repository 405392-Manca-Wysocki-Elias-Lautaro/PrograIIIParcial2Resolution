using Parcial2.ApiResponse;
using Parcial2.DTOs;
using Parcial2.Models;

namespace Parcial2.Services;

public interface IObrasService
{
    Task<List<ObraDto>> GetAllObras();
    Task<ApiResponse<AlbanilesXObra>> PostAlbanilXObra(AlbanilXObraDto albanilXObraDto);
    Task<List<AlbanilesXObra>> GetAllAXO();
}