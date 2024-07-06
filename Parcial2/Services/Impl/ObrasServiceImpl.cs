using AutoMapper;
using Parcial2.DTOs;
using Parcial2.Models;
using Parcial2.Repositories;

namespace Parcial2.Services.Impl;

public class ObrasServiceImpl : IObrasService
{
    private readonly IObrasRepository _obrasRepository;
    private readonly IMapper _mapper;

    public ObrasServiceImpl(IObrasRepository obrasRepository, IMapper mapper)
    {
        _obrasRepository = obrasRepository;
        _mapper = mapper;

    }
    
    public async Task<List<ObraDto>> getAll()
    {
        var obras = await _obrasRepository.getAllObras();

        if (obras != null)
        {
            List<ObraDto> activeObrasList = new List<ObraDto>();

            foreach (Obra obra in obras)
            {
                ObraDto activeObra = new ObraDto();
                activeObra.Nombre = obra.Nombre;
                activeObra.DatosVarios = obra.DatosVarios;
                var tipoObraTask = _obrasRepository.getTipoObraById(obra.IdTipoObra);
                TiposObra to = _mapper.Map<TiposObra>(tipoObraTask);
                activeObra.TipoObra = to.Nombre;
                activeObra.CantAlb = obra.AlbanilesXObras.Count;
                activeObrasList.Add(activeObra);
            }
            return activeObrasList;
        }

        throw new Exception("Obra not found");
    }
}