using aadrovez.Aplicacion.DTOs;
using aadrovez.Dominio.Entities;
using AutoMapper;

namespace aadrovez.Aplicacion.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TablaCodigoDto, TablaCodigo>().ReverseMap();
        }
    }
}
