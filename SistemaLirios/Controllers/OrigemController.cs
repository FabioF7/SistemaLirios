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
            try
            {
                List<OrigemModel> origem = await _origemRepository.BuscarTodasOrigens();

                if (origem == null)
                {
                    return BadRequest("Nenhuma Origem encontrado!");
                }

                return Ok(origem);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um Erro: {ex}");
            }
        }

        [HttpPost]
        [Authorize (Roles = "Admin")]
        public async Task<ActionResult<OrigemModel>> Insert([FromBody] OrigemModel origemModel)
        {
            try
            {
                OrigemModel origem = await _origemRepository.Insert(origemModel);

                if (origem == null)
                {
                    return BadRequest("Não foi possível incluir origem");
                }
            
                return Ok(origem);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um Erro: {ex}");
            }
        }

        [HttpPut("{id}")]
        [Authorize (Roles = "Admin")]
        public async Task<ActionResult<OrigemModel>> Update(int id, [FromBody] OrigemModel origemModel)
        {
            try
            {
                origemModel.Id = id;
                OrigemModel origem = await _origemRepository.Update(origemModel, id);

                if (origem == null)
                {
                    return BadRequest("Não foi possível alterar origem!");
                }

                return Ok(origem);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um Erro: {ex}");
            }
        }

        [HttpDelete("{id}")]
        [Authorize (Roles = "Admin")]
        public async Task<ActionResult<OrigemModel>> Delete(int id)
        {
            try
            {
                bool sucesso = await _origemRepository.Delete(id);

                if (!sucesso)
                {
                    return BadRequest("Não foi possível excluir origem!");
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
