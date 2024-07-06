using Parcial2.DTOs;
using Parcial2.Models;

namespace Parcial2.Services;

public interface IObrasService
{
    Task<List<ObraDto>> getAll();
}