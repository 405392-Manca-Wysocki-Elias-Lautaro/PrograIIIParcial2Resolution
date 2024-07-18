using Microsoft.EntityFrameworkCore;
using Parcial2.Context;
using Parcial2.Models;

namespace Parcial2.Repositories.Impl;

public class ObrasRepositoryImpl : IObrasRepository
{
    private readonly ContextDb _contextDb;

    public ObrasRepositoryImpl(ContextDb contextDb)
    {
        _contextDb = contextDb;
    }

    public async Task<List<Obra>> GetObras()
    {
        List<Obra> obra = await _contextDb.Obra.ToListAsync();

        if (obra != null)
        {
            return obra;
        }

        throw new Exception("Obra not found");
    }

    public  Task<TiposObra?> GetTipoObraById(Guid id)
    {
        var tipoObra =  _contextDb.TiposObras.Find(id);
        return Task.FromResult(tipoObra);
            
    }

    public Task<Obra?> GetObraById(Guid id)
    {
        var obra =  _contextDb.Obra.Find(id);
        return Task.FromResult(obra);

    }

    public Task<Albanile?> GetAlbanilById(Guid id)
    {
        var albanil = _contextDb.Albanile.Find(id);
        return Task.FromResult(albanil);
    }
    
    

    public async Task<AlbanilesXObra> GetByIdAlbanilXObra(Guid albanilId, Guid obraId)
    {
        return await _contextDb.AlbanilesXObra
            .FirstOrDefaultAsync(a => a.IdAlbanil == albanilId && a.IdObra == obraId);
    }

    public Task<AlbanilesXObra> PostAlbanilXObra(AlbanilesXObra albanilXObra)
    {
        var axo =  _contextDb.AlbanilesXObra.Add(albanilXObra);
        _contextDb.SaveChanges();
        return Task.FromResult(axo.Entity);
    }

    public async Task<List<AlbanilesXObra>> GetAlbanilesXObra(Guid obraId)
    {
        var axo = await _contextDb.AlbanilesXObra.Where(i => i.IdObra == obraId).ToListAsync();
        return axo;
    }

    public Task<Albanile> PostAlbanil(Albanile albanile)
    {
        var albanil = _contextDb.Albanile.Add(albanile);
        _contextDb.SaveChanges();
        return Task.FromResult(albanil.Entity);
    }

    public async Task<Albanile?> GetAlbanilByDni(string dni)
    {
        var albanil = await _contextDb.Albanile.FirstOrDefaultAsync(a => a.Dni == dni);
        return albanil;
    }

    public async Task<List<Albanile?>> GetAlbaniles(Guid id)
    {
        var albanilesGuid = await _contextDb.AlbanilesXObra
            .Where(axo => axo.IdObra == id)
            .Select(axo => axo.IdAlbanil)
            .ToListAsync();

        var albaniles = await _contextDb.Albanile.Where(a => !albanilesGuid.Contains(a.Id)).ToListAsync();
        return albaniles;
    }
}