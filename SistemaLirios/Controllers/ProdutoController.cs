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
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoRepository _produtoRepository;
        public ProdutoController(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        [HttpGet]
        [Authorize (Roles = "Admin")]
        public async Task<ActionResult<List<ProdutoModel>>> BuscarTodosProdutos()
        {
            try
            {
                List<ProdutoModel> produto = await _produtoRepository.BuscarTodosProdutos();

                if (produto == null)
                {
                    return BadRequest("Nenhum Produto encontrado!");
                }

                return Ok(produto);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um Erro: {ex}");
            }
        }

        [HttpGet("{id}")]
        [Authorize (Roles = "Admin")]
        public async Task<ActionResult<ProdutoModel>> BuscarPorId(int id)
        {
            try
            {
                ProdutoModel produto = await _produtoRepository.BuscarPorId(id);

                if (produto == null)
                {
                    return BadRequest("Produto não encontrado!");
                }

                return Ok(produto);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um Erro: {ex}");
            }
        }

        [HttpGet("Categoria/{idCategoria}")]
        [Authorize (Roles = "Admin")]
        public async Task<ActionResult<List<ProdutoModel>>> BuscarPorCategoria(int idCategoria)
        {
            try
            {
                List<ProdutoModel> produto = await _produtoRepository.BuscarPorCategoria(idCategoria);

                if (produto == null)
                {
                    return BadRequest("Nenhum Produto encontrado!");
                }

                return Ok(produto);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um Erro: {ex}");
            }
        }

        [HttpGet("Origem/{idOrigem}")]
        [Authorize (Roles = "Admin")]
        public async Task<ActionResult<List<ProdutoModel>>> BuscarPorOrigem(int idOrigem)
        {
            try
            {
                List<ProdutoModel> produto = await _produtoRepository.BuscarPorOrigem(idOrigem);

                if (produto == null)
                {
                    return BadRequest("Nenhum Produto encontrado!");
                }

                return Ok(produto);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um Erro: {ex}");
            }
        }

        [HttpGet("{dataInicio}/{dataFim}")]
        [Authorize (Roles = "Admin")]
        public async Task<ActionResult<ProdutoModel>> BuscarPorData(DateTime dataInicio, DateTime dataFim)
        {
            try
            {
                List<ProdutoModel> produto = await _produtoRepository.BuscarPorData(dataInicio, dataFim);

                if (produto == null)
                {
                    return BadRequest("Nenhum Produto encontrado!");
                }

                return Ok(produto);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um Erro: {ex}");
            }
        }

        [HttpPost]
        [Authorize (Roles = "Admin")]
        public async Task<ActionResult<ProdutoModel>> Insert([FromBody] ProdutoModel produtoModel)  //OK
        {
            try
            {
                ProdutoModel produto = await _produtoRepository.Insert(produtoModel);

                if (produto == null)
                {
                    return BadRequest("Não foi possível incluir produto!");
                }

                return Ok(produto);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um Erro: {ex}");
            }
        }

        [HttpPut("{id}")]
        [Authorize (Roles = "Admin")]
        public async Task<ActionResult<ProdutoModel>> Update(int id, [FromBody] ProdutoModel produtoModel)  //OK
        {
            try
            {
                produtoModel.Id = id;
                ProdutoModel produto = await _produtoRepository.Update(produtoModel, id);

                if (produto == null)
                {
                    return BadRequest("Não foi possível alterar produto!");
                }

                return Ok(produto);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um Erro: {ex}");
            }
        }

        [HttpDelete("{id}")]
        [Authorize (Roles = "Admin")]
        public async Task<ActionResult<ProdutoModel>> Delete(int id)  //OK
        {
            try
            {
                bool sucesso = await _produtoRepository.Delete(id);

                if (!sucesso)
                {
                    return BadRequest("Não foi possível excluir produto!");
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
