using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaLirios.Models;
using SistemaLirios.Repository;
using SistemaLirios.Repository.Interfaces;

namespace SistemaLirios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicoController : ControllerBase
    {
        private readonly IServicoRepository _servicoRepository;
        public ServicoController(IServicoRepository servicoRepository)
        {
            _servicoRepository = servicoRepository;
        }

        [HttpGet]
        [Authorize (Roles = "Admin")]
        public async Task<ActionResult<List<ServicoModel>>> BuscarTodosServicos()
        {
            try
            {
                List<ServicoModel> servico = await _servicoRepository.BuscarTodosServicos();

                if (servico == null)
                {
                    return BadRequest("Nenhum Servico encontrado!");
                }

                return Ok(servico);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um Erro: {ex}");
            }
        }


        [HttpGet("Tipo/{tipo}")]
        [Authorize (Roles = "Admin")]
        public async Task<ActionResult<ServicoModel>> BuscarPorTipo(int tipo)
        {
            try
            {
                List<ServicoModel> servico = await _servicoRepository.BuscarPorTipo(tipo);

                if (servico == null)
                {
                    return BadRequest("Nenhum Servico encontrado!");
                }

                return Ok(servico);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um Erro: {ex}");
            }
        }

        [HttpPost]
        [Authorize (Roles = "Admin")]
        public async Task<ActionResult<ServicoModel>> Insert([FromBody] ServicoModel servicoModel)
        {
            try
            {
                ServicoModel servico = await _servicoRepository.Insert(servicoModel);

                if (servico == null)
                {
                    return BadRequest("Não foi possível incluir servico!");
                }

                return Ok(servico);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um Erro: {ex}");
            }
        }

        [HttpPut("{id}")]
        [Authorize (Roles = "Admin")]
        public async Task<ActionResult<ServicoModel>> Update(int id, [FromBody] ServicoModel servicoModel)
        {
            try
            {
                servicoModel.Id = id;
                ServicoModel servico = await _servicoRepository.Update(servicoModel, id);

                if (servico == null)
                {
                    return BadRequest("Não foi possível alterar servico!");
                }

                return Ok(servico);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um Erro: {ex}");
            }
        }

        [HttpDelete("{id}")]
        [Authorize (Roles = "Admin")]
        public async Task<ActionResult<ServicoModel>> Delete(int id)
        {
            try
            {
                bool sucesso = await _servicoRepository.Delete(id);

                if (!sucesso)
                {
                    return BadRequest("Não foi possível excluir servico!");
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
