using Parcial2.Models;

namespace Parcial2.Repositories;

public interface IObrasRepository
{
    Task<List<Obra>> GetAllObras();
    Task<TiposObra> GetTipoObraById(Guid id);
    Task<Obra> GetObraById(Guid id);
    Task<Albanile> GetAlbanilById(Guid id);
    Task<List<AlbanilesXObra>> GetAlbanilesXObraByObraId(Guid obraId);
    Task<List<AlbanilesXObra>> GetAll();

}