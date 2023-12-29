using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaLirios.Models;
using SistemaLirios.Repository;
using SistemaLirios.Repository.Interfaces;

namespace SistemaLirios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrigemController : ControllerBase
    {
        private readonly IOrigemRepository _origemRepository;
        public OrigemController(IOrigemRepository origemRepository)
        {
            _origemRepository = origemRepository;
        }

        [HttpGet]
        [Authorize (Roles = "Admin")]
        public async Task<ActionResult<List<OrigemModel>>> BuscarTodasOrigens()
        {
            List<OrigemModel> origem = await _origemRepository.BuscarTodasOrigens();

            if (origem == null)
            {
                return BadRequest("Nenhuma Origem encontrado!");
            }

            return Ok(origem);
        }

        [HttpPost]
        [Authorize (Roles = "Admin")]
        public async Task<ActionResult<OrigemModel>> Insert([FromBody] OrigemModel origemModel)
        {
            OrigemModel origem = await _origemRepository.Insert(origemModel);

            if (origem == null)
            {
                return BadRequest("Não foi possível incluir origem");
            }
            
            return Ok(origem);
        }

        [HttpPut("{id}")]
        [Authorize (Roles = "Admin")]
        public async Task<ActionResult<OrigemModel>> Update(int id, [FromBody] OrigemModel origemModel)
        {
            origemModel.Id = id;
            OrigemModel origem = await _origemRepository.Update(origemModel, id);

            if (origem == null)
            {
                return BadRequest("Não foi possível alterar origem!");
            }

            return Ok(origem);
        }

        [HttpDelete("{id}")]
        [Authorize (Roles = "Admin")]
        public async Task<ActionResult<OrigemModel>> Delete(int id)
        {
            bool sucesso = await _origemRepository.Delete(id);

            if (!sucesso)
            {
                return BadRequest("Não foi possível excluir origem!");
            }

            return Ok(sucesso);
        }
    }
}
