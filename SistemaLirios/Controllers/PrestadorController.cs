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
        [Authorize]
        public async Task<ActionResult<List<PrestadorModel>>> BuscarTodosPrestadores()
        {
            List<PrestadorModel> prestador = await _prestadorRepository.BuscarTodosPrestadores();

            if (prestador == null)
            {
                return BadRequest("Nenhum prestador encontrado!");
            }

            return Ok(prestador);
        }


        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<PrestadorModel>> BuscarPorId(int id)
        {
            PrestadorModel prestador = await _prestadorRepository.BuscarPorId(id);

            if (prestador == null)
            {
                return BadRequest("Prestador não encontrado!");
            }

            return Ok(prestador);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<PrestadorModel>> Insert([FromBody] PrestadorModel prestadorModel)
        {
            PrestadorModel prestador = await _prestadorRepository.Insert(prestadorModel);

            if (prestador == null)
            {
                return BadRequest("Não foi possível incluir prestador!");
            }

            return Ok(prestador);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult<PrestadorModel>> Update(int id, [FromBody] PrestadorModel prestadorModel)
        {
            prestadorModel.Id = id;
            PrestadorModel prestador = await _prestadorRepository.Update(prestadorModel, id);

            if (prestador == null)
            {
                return BadRequest("Não foi possível alterar prestador!");
            }

            return Ok(prestador);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<PrestadorModel>> Delete(int id)
        {
            bool sucesso = await _prestadorRepository.Delete(id);

            if (!sucesso)
            {
                return BadRequest("Não foi possível excluir prestador!");
            }

            return Ok(sucesso);
        }
    }
}
