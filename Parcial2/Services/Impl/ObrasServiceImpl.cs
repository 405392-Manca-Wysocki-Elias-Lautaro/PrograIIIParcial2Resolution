using AutoMapper;
using Parcial2.ApiResponse;
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
    
    public async Task<List<ObraDto>> GetAllObras()
    {
        var obras = await _obrasRepository.GetAllObras();

        if (obras != null)
        {
            List<ObraDto> activeObrasList = new List<ObraDto>();

            foreach (Obra obra in obras)
            {
                ObraDto activeObra = new ObraDto();
                activeObra.Nombre = obra.Nombre;
                activeObra.DatosVarios = obra.DatosVarios;
                var tipoObraTask = _obrasRepository.GetTipoObraById(obra.IdTipoObra);
                TiposObra to = _mapper.Map<TiposObra>(tipoObraTask);
                activeObra.TipoObra = to.Nombre;
                activeObra.CantAlb = obra.AlbanilesXObras.Count;
                activeObrasList.Add(activeObra);
            }
            return activeObrasList;
        }

        throw new Exception("Obra not found");
    }

    public async Task<ApiResponse<AlbanilesXObra>> PostAlbanilXObra(AlbanilXObraDto albanilXObraDto)
    {
        var albanilesXObra = await _obrasRepository.GetAlbanilesXObraByObraId(albanilXObraDto.Obra.Id);

        return null;
    }

    public async Task<List<AlbanilesXObra>> GetAllAXO()
    {
        var albanilesXObra = await _obrasRepository.GetAll();

        if (albanilesXObra != null)
        {
            return albanilesXObra;
        }

        throw new Exception("Albañiles not found");
        
    }
}