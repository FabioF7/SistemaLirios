using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaLirios.Models;
using SistemaLirios.Repository;
using SistemaLirios.Repository.Interfaces;

namespace SistemaLirios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventarioDetalhesController : ControllerBase
    {
        private readonly IInventarioDetallhesRepository _InventarioDetalhesRepository;

        public InventarioDetalhesController(IInventarioDetallhesRepository InventarioDetalhesRepository)
        {
            _InventarioDetalhesRepository = InventarioDetalhesRepository;
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<InventarioDetalhesModel>>> BuscarTodosItensInventarioPorId(int id)
        {
            try
            {
                List<InventarioDetalhesModel> Inventario = await _InventarioDetalhesRepository.BuscarTodosItensInventarioPorId(id);

                if (Inventario == null)
                {
                    return BadRequest("Nenhum Inventario encontrado!");
                }

                return Ok(Inventario);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um Erro: {ex}");
            }
        }

        [HttpPost()]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<InventarioDetalhesModel>> Insert([FromBody] List<InventarioDetalhesModel> InventarioDetalhesModel)
        {
            try
            {
                List<InventarioDetalhesModel> Inventario = await _InventarioDetalhesRepository.Insert(InventarioDetalhesModel);

                if (Inventario == null)
                {
                    return BadRequest("Não foi possível incluir Inventario!");
                }

                return Ok(Inventario);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um Erro: {ex}");
            }
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<InventarioDetalhesModel>> Update(int id, [FromBody] InventarioDetalhesModel  InventarioDetalhesModel)
        {
            try
            {
                InventarioDetalhesModel.Id = id;
                InventarioDetalhesModel Inventario = await _InventarioDetalhesRepository.Update(InventarioDetalhesModel, id);

                if (Inventario == null)
                {
                    return BadRequest("Não foi possível alterar Inventario!");
                }

                return Ok(Inventario);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um Erro: {ex}");
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<InventarioDetalhesModel>> Delete(int id)
        {
            try
            {
                bool sucesso = await _InventarioDetalhesRepository.Delete(id);

                if (!sucesso)
                {
                    return BadRequest("Não foi possível excluir Inventario!");
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
