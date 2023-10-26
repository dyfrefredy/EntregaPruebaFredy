using Common.Dto;
using Common.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IUsuarioBusiness
    {
        ResultDto<UsuarioDTO> GetUsuario();

        ResultDto<UsuarioDTO> SaveUsuario(UsuarioDTO usuarioDTO);

        void UpdateUsuario(UsuarioDTO usuarioDTO);

        void DeleteUsuario(int id);
    }
}
