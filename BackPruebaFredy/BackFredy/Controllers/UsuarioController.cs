using Business.Interfaces;
using Common.Dto;
using Common.Utility;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackFredy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        IUsuarioBusiness _tableroBusiness;

        public UsuarioController(IUsuarioBusiness tableroBusiness)
        {
            _tableroBusiness = tableroBusiness;
        }


        // GET: api/<UsuarioController>
        [HttpGet]
        public ResultDto<UsuarioDTO> Get()
        {
            return _tableroBusiness.GetUsuario();
        }

        // POST api/<CityController>
        [HttpPost]
        public ResultDto<UsuarioDTO> Post([FromBody] UsuarioDTO cityDto)
        {
            var result = _tableroBusiness.SaveUsuario(cityDto);
            return result;
        }

        // PUT api/<UsuarioController>/5
        [HttpPut("{id}")]
        public void Put([FromBody] UsuarioDTO usuarioDTO)
        {
            _tableroBusiness.UpdateUsuario(usuarioDTO);
        }

        // DELETE api/<UsuarioController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _tableroBusiness.DeleteUsuario(id);
        }
    }
}
