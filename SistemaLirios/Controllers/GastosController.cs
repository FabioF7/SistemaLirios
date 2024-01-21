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
    public class GastosController : ControllerBase
    {
        private readonly IGastosRepository _gastosRepository;
        public GastosController(IGastosRepository gastosRepository)
        {
            _gastosRepository = gastosRepository;
        }

        [HttpGet("Todos")]
        [Authorize (Roles = "Admin")]
        public async Task<ActionResult<List<GastosModel>>> BuscarTodosGastos()  //OK
        {
            try
            {
                List<GastosModel> gastos = await _gastosRepository.BuscarTodosGastos();

                if (gastos == null)
                {
                    return BadRequest("Nenhum gasto encontrado!");
                }

                return Ok(gastos);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um Erro: {ex}");
            }
        }

        [HttpGet("{TipoServicoId}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<GastosModel>>> BuscarPorTipoServicoId(int TipoServicoId)  //OK
        {
            try
            {
                List<GastosModel> gastos = await _gastosRepository.BuscarPorTipoServicoId(TipoServicoId);

                if (gastos == null)
                {
                    return BadRequest("Nenhum gasto encontrado!");
                }

                return Ok(gastos);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um Erro: {ex}");
            }
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<GastosModel>>> BuscarRecorrente()  //OK
        {
            try
            {
                List<GastosModel> gastos = await _gastosRepository.BuscarRecorrente();

                if (gastos == null)
                {
                    return BadRequest("Nenhum gasto encontrado!");
                }

                return Ok(gastos);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um Erro: {ex}");
            }
}


        [HttpGet("{dataInicio}/{dataFim}")]
        [Authorize (Roles = "Admin")]
        public async Task<ActionResult<GastosModel>> BuscarPorData(DateTime dataInicio, DateTime dataFim)
        {
            try
            {
                List<GastosModel> gastos = await _gastosRepository.BuscarPorData(dataInicio, dataFim);

                if (gastos == null)
                {
                    return BadRequest("Nenhum gasto encontrado!");
                }

                return Ok(gastos);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um Erro: {ex}");
            }
        }

        [HttpPost]
        [Authorize (Roles = "Admin")]
        public async Task<ActionResult<GastosModel>> Insert([FromBody] GastosModel gastosModel)  //OK
        {
            try
            {
                GastosModel gastos = await _gastosRepository.Insert(gastosModel);

                if (gastos == null)
                {
                    return BadRequest("Não foi possível incluir gasto!");
                }

                return Ok(gastos);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um Erro: {ex}");
            }
        }

        [HttpPut("{id}")]
        [Authorize (Roles = "Admin")]
        public async Task<ActionResult<GastosModel>> Update(int id, [FromBody] GastosModel gastosModel)  //OK
        {
            try
            {
                gastosModel.Id = id;
                GastosModel gastos = await _gastosRepository.Update(gastosModel, id);

                if (gastos == null)
                {
                    return BadRequest("Não foi possível alterar gasto!");
                }

                return Ok(gastos);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um Erro: {ex}");
            }
}

        [HttpDelete("{id}")]
        [Authorize (Roles = "Admin")]
        public async Task<ActionResult<GastosModel>> Delete(int id)  //OK
        {
            try
            {
                bool sucesso = await _gastosRepository.Delete(id);

                if (!sucesso)
                {
                    return BadRequest("Não foi possível excluir gasto!");
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
