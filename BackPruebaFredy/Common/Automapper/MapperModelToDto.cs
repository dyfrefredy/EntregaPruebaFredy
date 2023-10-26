using AutoMapper;
using Common.Dto;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Automapper
{
    public class MapperModelToDto : Profile
    {
        public MapperModelToDto()
        {
            CreateMap<Usuario, UsuarioDTO>()
                .ForMember(x => x.IdDTO, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.NombreDTO, y => y.MapFrom(z => z.Nombre))
                .ForMember(x => x.FechaNacimientoDTO, y => y.MapFrom(z => z.FechaNacimiento))
                .ForMember(x => x.SexoDTO, y => y.MapFrom(z => z.Sexo));
        }
    }
}
