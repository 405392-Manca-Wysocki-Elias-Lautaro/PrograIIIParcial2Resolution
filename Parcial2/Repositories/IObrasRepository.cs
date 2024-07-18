using Parcial2.Models;

namespace Parcial2.Repositories;

public interface IObrasRepository
{
    Task<List<Obra>> GetObras();
    Task<TiposObra> GetTipoObraById(Guid id);
    Task<Obra> GetObraById(Guid id);
    Task<Albanile> GetAlbanilById(Guid id);
    Task<AlbanilesXObra> GetByIdAlbanilXObra(Guid albanilId,  Guid obraId);
    Task<AlbanilesXObra> PostAlbanilXObra(AlbanilesXObra albanilXObra);
    Task<List<AlbanilesXObra?>> GetAlbanilesXObra(Guid obraId);
    Task<Albanile> PostAlbanil(Albanile albanile);
    Task<Albanile> GetAlbanilByDni(String dni);
    Task<List<Albanile>> GetAlbaniles(Guid id);
}