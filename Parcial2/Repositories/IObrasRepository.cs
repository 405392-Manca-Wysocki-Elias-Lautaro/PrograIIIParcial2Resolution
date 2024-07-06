using Parcial2.Models;

namespace Parcial2.Repositories;

public interface IObrasRepository
{
    Task<List<Obra>> getAllObras();
    Task<TiposObra> getTipoObraById(Guid id);
}