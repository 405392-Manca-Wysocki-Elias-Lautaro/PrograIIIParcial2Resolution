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
    
    public async Task<List<ObrasDto>> GetObras()
    {
        var obras = await _obrasRepository.GetObras();

        if (obras != null)
        {
            List<ObrasDto> activeObrasList = new List<ObrasDto>();

            foreach (Obra obra in obras)
            {
                ObrasDto activeObras = new ObrasDto();
                activeObras.Id = obra.Id;
                activeObras.Nombre = obra.Nombre;
                activeObras.DatosVarios = obra.DatosVarios;
                var tipoObraTask = _obrasRepository.GetTipoObraById(obra.IdTipoObra).Result;
                activeObras.TipoObra = tipoObraTask.Nombre;
                activeObras.CantAlb = obra.AlbanilesXObras.Count;

                var axo = _obrasRepository.GetAlbanilesXObra(obra.Id).Result;

                if (axo.Count > 0)
                {
                    activeObras.CantAlb = axo.Count;
                    activeObrasList.Add(activeObras);
                }
            }
            return activeObrasList;
        }

        throw new Exception("Obra not found");
    }

    public async Task<AlbanilXObraDto> PostAlbanilXObra(AlbanilXObraDto albanilXObraDto)
    {
        var albanilesXObraExist = await _obrasRepository.GetByIdAlbanilXObra(albanilXObraDto.AlbanilId, albanilXObraDto.ObraId);

        if (albanilesXObraExist != null)
        {
            throw new DuplicateEntryExeption("El registro ya existe");
        }

        var axo = new AlbanilesXObra()
        {
            Id = new Guid(),
            IdAlbanil = albanilXObraDto.AlbanilId,
            IdAlbanilNavigationId = albanilXObraDto.AlbanilId,
            IdObra = albanilXObraDto.ObraId,
            IdObraNavigationId = albanilXObraDto.ObraId,
            TareaArealizar = albanilXObraDto.TareaARealizar,
            FechaAlta = albanilXObraDto.FechaAlta,
        };

        var result = await _obrasRepository.PostAlbanilXObra(axo);

        var axoDto = new AlbanilXObraDto()
        {
            Id = result.Id,
            AlbanilId = result.IdAlbanil,
            ObraId = result.IdObra,
            TareaARealizar = result.TareaArealizar,
            FechaAlta = result.FechaAlta
        };

        return axoDto;

    }

    public async Task<AlbanilDto> PostAlbanil(AlbanilDto albanilDto)
    {
        var albanilExist = await _obrasRepository.GetAlbanilByDni(albanilDto.Dni);

        if (albanilExist != null)
        {
            throw new DuplicateEntryExeption("El registro ya existe");
        }

        var albanil = new Albanile()
        {
            Id = new Guid(),
            Nombre = albanilDto.Nombre,
            Apellido = albanilDto.Apellido,
            Dni = albanilDto.Dni,
            Calle = albanilDto.Calle,
            Numero = albanilDto.Numero,
            Telefono = albanilDto.Telefono,
            CodPost = albanilDto.CodPost,
            Activo = albanilDto.Activo,
            FechaAlta = albanilDto.FechaAlta
        };

        var result = await _obrasRepository.PostAlbanil(albanil);

        var albanilDtoResult = new AlbanilDto()
        {
            Nombre = result.Nombre,
            Apellido = result.Apellido,
            Dni = result.Dni,
            Telefono = result.Telefono,
            Calle = result.Calle,
            Numero = result.Numero,
            CodPost = result.CodPost,
            Activo = result.Activo
        };

        return albanilDtoResult;
    }

    public async Task<List<AlbanilDto>> GetAlbaniles(Guid obraId)
    {
        var albaniles = await _obrasRepository.GetAlbaniles(obraId);

        var albanileList = new List<AlbanilDto>();
        foreach (Albanile? a in albaniles)
        {
            AlbanilDto albanilDto = new AlbanilDto()
            {
                Id = a.Id,
                Nombre = a.Nombre,
                Apellido = a.Apellido,
                Dni = a.Dni,
                Telefono = a.Telefono,
                Calle = a.Calle,
                Numero = a.Numero,
                CodPost = a.CodPost,
                Activo = a.Activo
            };
            
            albanileList.Add(albanilDto);
        }

        return albanileList;
    }
}