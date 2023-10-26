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
    public class MapperDtoToModel : Profile
    {
        public MapperDtoToModel()
        {
            CreateMap<UsuarioDTO, Usuario>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.IdDTO))
                .ForMember(x => x.Nombre, y => y.MapFrom(z => z.NombreDTO))
                .ForMember(x => x.FechaNacimiento, y => y.MapFrom(z => z.FechaNacimientoDTO))
                .ForMember(x => x.Sexo, y => y.MapFrom(z => z.SexoDTO));
        }

    }
}
