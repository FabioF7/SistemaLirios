using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaLirios.Models;
using SistemaLirios.Repository;
using SistemaLirios.Repository.Interfaces;

namespace SistemaLirios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrestadorController : ControllerBase
    {
        private readonly IPrestadorRepository _prestadorRepository;
        public PrestadorController(IPrestadorRepository prestadorRepository)
        {
            _prestadorRepository = prestadorRepository;
        }

        [HttpGet]
        [Authorize (Roles = "Admin")]
        public async Task<ActionResult<List<PrestadorModel>>> BuscarTodosPrestadores()
        {
            try
            {
                List<PrestadorModel> prestador = await _prestadorRepository.BuscarTodosPrestadores();

                if (prestador == null)
                {
                    return BadRequest("Nenhum prestador encontrado!");
                }

                return Ok(prestador);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um Erro: {ex}");
            }
        }


        [HttpGet("{id}")]
        [Authorize (Roles = "Admin")]
        public async Task<ActionResult<PrestadorModel>> BuscarPorId(int id)
        {
            try
            {
                PrestadorModel prestador = await _prestadorRepository.BuscarPorId(id);

                if (prestador == null)
                {
                    return BadRequest("Prestador não encontrado!");
                }

                return Ok(prestador);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um Erro: {ex}");
            }
        }

        [HttpPost]
        [Authorize (Roles = "Admin")]
        public async Task<ActionResult<PrestadorModel>> Insert([FromBody] PrestadorModel prestadorModel)
        {
            try
            {
                PrestadorModel prestador = await _prestadorRepository.Insert(prestadorModel);

                if (prestador == null)
                {
                    return BadRequest("Não foi possível incluir prestador!");
                }

                return Ok(prestador);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um Erro: {ex}");
            }
        }

        [HttpPut("{id}")]
        [Authorize (Roles = "Admin")]
        public async Task<ActionResult<PrestadorModel>> Update(int id, [FromBody] PrestadorModel prestadorModel)
        {
            try
            {
                prestadorModel.Id = id;
                PrestadorModel prestador = await _prestadorRepository.Update(prestadorModel, id);

                if (prestador == null)
                {
                    return BadRequest("Não foi possível alterar prestador!");
                }

                return Ok(prestador);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um Erro: {ex}");
            }
        }

        [HttpDelete("{id}")]
        [Authorize (Roles = "Admin")]
        public async Task<ActionResult<PrestadorModel>> Delete(int id)
        {
            try
            {
                bool sucesso = await _prestadorRepository.Delete(id);

                if (!sucesso)
                {
                    return BadRequest("Não foi possível excluir prestador!");
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
