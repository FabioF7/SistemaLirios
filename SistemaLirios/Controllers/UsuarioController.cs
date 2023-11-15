using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaLirios.Models;
using SistemaLirios.Repository;
using SistemaLirios.Repository.Interfaces;

namespace SistemaLirios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public UsuarioController(IUsuarioRepository usuarioRepository) 
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<UsuarioModel>> Insert([FromBody] UsuarioModel usuarioModel)
        {
            UsuarioModel usuario = await _usuarioRepository.Insert(usuarioModel);

            if (usuario == null)
            {
                return BadRequest("Não foi possível incluir Usuario!");
            }

            return Ok(usuario);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult<UsuarioModel>> Update(int id, [FromBody] UsuarioModel usuarioModel)
        {
            usuarioModel.UserID = id;
            UsuarioModel usuario = await _usuarioRepository.Update(usuarioModel, id);

            if (usuario == null)
            {
                return BadRequest("Não foi possível alterar Usuario!");
            }

            return Ok(usuario);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<UsuarioModel>> Delete(int id)
        {
            bool sucesso = await _usuarioRepository.Delete(id);

            if (!sucesso)
            {
                return BadRequest("Não foi possível excluir Usuario!");
            }

            return Ok(sucesso);
        }
    }
}
