using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaLirios.Models;
using SistemaLirios.Repository;
using SistemaLirios.Repository.Interfaces;

namespace SistemaLirios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagamentoController : ControllerBase
    {
        private readonly IPagamentoRepository _pagamentoRepository;
        private readonly IVendaRepository _vendaRepository;

        public PagamentoController(IPagamentoRepository pagamentoRepository, IVendaRepository vendaRepository)
        {
            _pagamentoRepository = pagamentoRepository;
            _vendaRepository = vendaRepository;
        }

        [HttpGet()]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<PagamentoModel>>> BuscarTodosPagamentos()
        {
            try
            {
                List<PagamentoModel> pagamento = await _pagamentoRepository.BuscarTodosPagamentos();

                if (pagamento == null)
                {
                    return BadRequest("Nenhum Pagamento encontrado!");
                }

                return Ok(pagamento);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um Erro: {ex}");
            }
        }

        [HttpGet("Cliente/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<PagamentoModel>> BuscarPorIdCliente(int id)  //OK
        {
            try
            {
                List<PagamentoModel> pagamento = await _pagamentoRepository.BuscarPorIdCliente(id);

                if (pagamento == null)
                {
                    return BadRequest($"Pagamentos para o Cliente {id} não encontradas!");
                }

                return Ok(pagamento);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um Erro: {ex}");
            }
        }

        [HttpGet("Divida/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<float>> RetornaDivida(int id)
        {
            try
            {
                List<PagamentoModel> pagamento = await _pagamentoRepository.BuscarPorIdCliente(id);

                if (pagamento == null)
                {
                    return BadRequest($"Pagamentos para o Cliente {id} não encontradas!");
                }

                List<VendaModel> venda = await _vendaRepository.BuscarPorIdCliente(id);

                if (pagamento == null)
                {
                    return BadRequest($"Vendas para o Cliente {id} não encontradas!");
                }

                return Ok(_pagamentoRepository.RetornaDivida(pagamento, venda));

            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um Erro: {ex}");
            }
        }

        [HttpPost()]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<PagamentoModel>> Insert([FromBody] PagamentoModel pagamentoModel)
        {
            try
            {
                PagamentoModel pagamento = await _pagamentoRepository.Insert(pagamentoModel);

                if (pagamento == null)
                {
                    return BadRequest("Não foi possível incluir pagamento!");
                }

                return Ok(pagamento);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um Erro: {ex}");
            }
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<PagamentoModel>> Update(int id, [FromBody] PagamentoModel pagamentoModel)
        {
            try
            {
                pagamentoModel.Id = id;
                PagamentoModel Pagamento = await _pagamentoRepository.Update(pagamentoModel, id);

                if (Pagamento == null)
                {
                    return BadRequest("Não foi possível alterar Pagamento!");
                }

                return Ok(Pagamento);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um Erro: {ex}");
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<PagamentoModel>> Delete(int id)
        {
            try
            {
                bool sucesso = await _pagamentoRepository.Delete(id);

                if (!sucesso)
                {
                    return BadRequest("Não foi possível excluir Pagamento!");
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
