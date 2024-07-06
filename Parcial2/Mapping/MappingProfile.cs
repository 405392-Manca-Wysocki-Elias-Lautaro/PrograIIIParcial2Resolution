using AutoMapper;
using Parcial2.Models;

namespace Parcial2.Mapping;

public class MappingProfile : Profile
{ 
    public MappingProfile() 
    {
        CreateMap<Task<TiposObra>, TiposObra>();
    }
}