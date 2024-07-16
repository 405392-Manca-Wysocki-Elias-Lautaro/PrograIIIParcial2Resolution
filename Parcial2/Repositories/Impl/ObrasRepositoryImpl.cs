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

    public async Task<List<Obra>> GetAllObras()
    {
        List<Obra> obra = await _contextDb.Obra.ToListAsync();
        var v = "";

        if (obra != null)
        {
            return obra;
        }

        throw new Exception("Obra not found");
    }

    public async Task<TiposObra> GetTipoObraById(Guid id)
    {
        var tipoObra = await _contextDb.TiposObras.FirstOrDefaultAsync(to => to.Id == id);

        if (tipoObra != null)
        {
            return tipoObra;
        }

        throw new Exception("Tipo Obra not found");
    }

    public async Task<Obra> GetObraById(Guid id)
    {
        var obra = await _contextDb.Obra.FirstOrDefaultAsync(o => o.Id == id);

        if (obra != null)
        {
            return obra;
        }

        throw new Exception("Obra not found");

    }

    public async Task<Albanile> GetAlbanilById(Guid id)
    {
        var albanil = await _contextDb.Albaniles.FirstOrDefaultAsync(a => a.Id == id);

        if (albanil != null)
        {
            return albanil;
        }
        throw new Exception("Albañil not found");
    }

    public async Task<List<AlbanilesXObra>> GetAlbanilesXObraByObraId(Guid obraId)
    {
        var albanilesXObra = await _contextDb.AlbanilesXObras
            .FromSql($"SELECT * FROM [AlbanilesXObra] WHERE IdObra = {obraId}")
            .ToListAsync();

        if (albanilesXObra != null)
        {
            return albanilesXObra;
        }

        throw new Exception("No masons were found for this job.");
    }

    public async Task<List<AlbanilesXObra>> GetAll()
    {
        var albanilesXObra = await _contextDb.AlbanilesXObras.ToListAsync();

        if (albanilesXObra != null)
        {
            return albanilesXObra;
        }

        throw new Exception("Albaniles not found ");
    }
}