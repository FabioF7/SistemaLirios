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
    public class PerfilController : ControllerBase
    {
        private readonly IPerfilRepository _perfilRepository;
        public PerfilController(IPerfilRepository perfilRepository) 
        {
            _perfilRepository = perfilRepository;
        }

        [HttpGet]
        [Authorize (Roles = "Admin")]
        public async Task<ActionResult<List<PerfilModel>>> BuscarTodosPerfis()
        {
            try
            {
                List<PerfilModel> perfil = await _perfilRepository.BuscarTodosPerfis();

                if(perfil == null)
                {
                    return BadRequest("Nenhum Perfil encontrado!");
                }

                return Ok(perfil);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um Erro: {ex}");
            }
        }

        [HttpGet("{id}")]
        [Authorize (Roles = "Admin")]
        public async Task<ActionResult<PerfilModel>> BuscarPorId(int id)
        {
            try
            {
                PerfilModel perfil = await _perfilRepository.BuscarPorId(id);

                if (perfil == null)
                {
                    return BadRequest("Perfil não encontrado!");
                }

                return Ok(perfil);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um Erro: {ex}");
            }
        }

        [HttpPost]
        [Authorize (Roles = "Admin")]
        public async Task<ActionResult<PerfilModel>> Insert([FromBody] PerfilModel perfilModel)
        {
            try
            {
                PerfilModel perfil = await _perfilRepository.Insert(perfilModel);

                if (perfil == null)
                {
                    return BadRequest("Não foi possível incluir Perfil!");
                }

                return Ok(perfil);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um Erro: {ex}");
            }
        }

        [HttpPut("{id}")]
        [Authorize (Roles = "Admin")]
        public async Task<ActionResult<PerfilModel>> Update(int id, [FromBody] PerfilModel perfilModel)
        {
            try
            {
                perfilModel.Id = id;
                PerfilModel perfil = await _perfilRepository.Update(perfilModel, id);

                if (perfil == null)
                {
                    return BadRequest("Não foi possível alterar Perfil!");
                }

                return Ok(perfil);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um Erro: {ex}");
            }
        }

        [HttpDelete("{id}")]
        [Authorize (Roles = "Admin")]
        public async Task<ActionResult<PerfilModel>> Delete(int id)
        {
            try
            {
                bool sucesso = await _perfilRepository.Delete(id);

                if (!sucesso)
                {
                    return BadRequest("Não foi possível excluir Perfil!");
                }

                return Ok(sucesso);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um Erro: {ex}");
            }
        }
    }
}
