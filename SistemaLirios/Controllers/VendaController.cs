using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaLirios.Models;
using SistemaLirios.Repository.Interfaces;

namespace SistemaLirios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendaController : ControllerBase
    {
        private readonly IVendaRepository _vendaRepository;
        public VendaController(IVendaRepository vendaRepository)
        {
            _vendaRepository = vendaRepository;
        }

        [HttpGet()]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<VendaModel>>> BuscarTodosVendas()
        {
            try
            {
                List<VendaModel> venda = await _vendaRepository.BuscarTodosVendas();

                if (venda == null)
                {
                    return BadRequest("Nenhum venda encontrado!");
                }

                return Ok(venda);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um Erro: {ex}");
            }
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<VendaModel>> BuscarPorId(int id)  //OK
        {
            try
            {
                VendaModel venda = await _vendaRepository.BuscarPorId(id);

                if (venda == null)
                {
                    return BadRequest("Venda não encontrada!");
                }

                return Ok(venda);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um Erro: {ex}");
            }
        }

        [HttpGet("Cliente/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<VendaModel>> BuscarPorIdCliente(int id)  //OK
        {
            try
            {
                List<VendaModel> venda = await _vendaRepository.BuscarPorIdCliente(id);

                if (venda == null)
                {
                    return BadRequest($"Vendas para o Cliente {id} não encontradas!");
                }

                return Ok(venda);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um Erro: {ex}");
            }
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<IEnumerable<VendaModel>>> Insert([FromBody] List<VendaModel> vendas)
        {
            try
            {
                IEnumerable<VendaModel> vendasInseridas = await _vendaRepository.Insert(vendas);

                if (vendasInseridas == null || !vendasInseridas.Any())
                {
                    return BadRequest("Não foi possível incluir vendas!");
                }

                return Ok(vendasInseridas);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um Erro: {ex}");
            }
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<VendaModel>> Update(int id, [FromBody] VendaModel vendaModel)  //OK
        {
            try
            {
                vendaModel.Id = id;
                VendaModel venda = await _vendaRepository.Update(vendaModel, id);

                if (venda == null)
                {
                    return BadRequest("Não foi possível alterar venda!");
                }

                return Ok(venda);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um Erro: {ex}");
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<VendaModel>> Delete(int id)  //OK
        {
            try
            {
                bool sucesso = await _vendaRepository.Delete(id);

                if (!sucesso)
                {
                    return BadRequest("Não foi possível excluir venda!");
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
