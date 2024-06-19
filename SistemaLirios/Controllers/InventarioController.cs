using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaLirios.Models;
using SistemaLirios.Repository;
using SistemaLirios.Repository.Interfaces;

namespace SistemaLirios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventarioController : ControllerBase
    {
        private readonly IInventarioRepository _InventarioRepository;

        public InventarioController(IInventarioRepository InventarioRepository)
        {
            _InventarioRepository = InventarioRepository;
        }

        [HttpGet()]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<InventarioModel>>> BuscarTodosInventarios()
        {
            try
            {
                List<InventarioModel> Inventario = await _InventarioRepository.BuscarTodosInventarios();

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

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<InventarioModel>> BuscarPorId(int id)  //OK
        {
            try
            {
                InventarioModel Inventario = await _InventarioRepository.BuscarPorId(id);

                if (Inventario == null)
                {
                    return BadRequest($"Inventarios para o Cliente {id} não encontradas!");
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
        public async Task<ActionResult<InventarioModel>> Insert([FromBody] InventarioModel InventarioModel)
        {
            try
            {
                InventarioModel Inventario = await _InventarioRepository.Insert(InventarioModel);

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
        public async Task<ActionResult<InventarioModel>> Update(int id, [FromBody] InventarioModel InventarioModel)
        {
            try
            {
                InventarioModel.Id = id;
                InventarioModel Inventario = await _InventarioRepository.Update(InventarioModel, id);

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
        public async Task<ActionResult<InventarioModel>> Delete(int id)
        {
            try
            {
                bool sucesso = await _InventarioRepository.Delete(id);

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
