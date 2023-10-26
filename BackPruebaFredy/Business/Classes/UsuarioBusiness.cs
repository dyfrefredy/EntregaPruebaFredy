using AutoMapper;
using Business.Interfaces;
using Common.Dto;
using Common.Utility;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Classes
{
    public class UsuarioBusiness : IUsuarioBusiness
    {
        private bd_prueba_fredyContext db;
        private readonly IMapper mapper;
        private Logger logger = LogManager.GetCurrentClassLogger();

        public UsuarioBusiness(bd_prueba_fredyContext db,
                               IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }


        public ResultDto<UsuarioDTO> GetUsuario()
        {
            ResultDto<UsuarioDTO> resultDto = new ResultDto<UsuarioDTO>();
            try
            {
                var list = db.Usuarios.ToList();

                if (list.Count > 0)
                {
                    List<UsuarioDTO> usuarioDTOs = this.mapper.Map<List<Usuario>, List<UsuarioDTO>>(list);

                    resultDto.BusinessDto = new List<UsuarioDTO>();
                    resultDto.BusinessDto = usuarioDTOs;
                    resultDto.ResponseDto = new ResponseDto()
                    {
                        Message = "La consulta de usuarios se realizó de forma exitosa",
                        Response = ResponseType.OK.GetDescription()
                    };
                }
                else
                {
                    resultDto.ResponseDto = new ResponseDto()
                    {
                        Message = "LaLa consulta de usuarios no arrojo ningún resultado",
                        Response = ResponseType.WARNING.GetDescription()
                    };
                }
            }
            catch (Exception ex)
            {

                resultDto.BusinessDto = null;
                resultDto.ResponseDto = new ResponseDto()
                {
                    Message = "La consulta de usuarios genero un error",
                    Response = ResponseType.ERROR.GetDescription()
                };
                logger.Error(ex.ToString());
            }

            

            return resultDto;
        }

        public ResultDto<UsuarioDTO> SaveUsuario(UsuarioDTO usuarioDTO)
        {
            ResultDto<UsuarioDTO> resultDto = new ResultDto<UsuarioDTO>();
            try
            {
                Usuario usuario = this.mapper.Map<UsuarioDTO, Usuario>(usuarioDTO);

                db.Usuarios.Add(usuario);
                db.SaveChanges();

                resultDto.ResponseDto = new ResponseDto()
                {
                    Message = "La creación del usuario se realizó correctamente",
                    Response = ResponseType.OK.GetDescription()
                };
            }
            catch (Exception ex)
            {

                resultDto.BusinessDto = null;
                resultDto.ResponseDto = new ResponseDto()
                {
                    Message = "La creación del usuario generó un error",
                    Response = ResponseType.ERROR.GetDescription()
                };
                logger.Error(ex.ToString());
            }

            return resultDto;
        }

        public void UpdateUsuario(UsuarioDTO usuarioDTO)
        {
            throw new NotImplementedException();
        }

        public void DeleteUsuario(int id)
        {
            throw new NotImplementedException();
        }
    }
}
