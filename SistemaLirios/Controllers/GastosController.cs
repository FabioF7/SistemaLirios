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

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<GastosModel>>> BuscarTodosGastos()  //OK
        {
            List<GastosModel> gastos = await _gastosRepository.BuscarTodosGastos();

            if (gastos == null)
            {
                return BadRequest("Nenhum gasto encontrado!");
            }

            return Ok(gastos);
        }


        [HttpGet("{dataInicio}/{dataFim}")]
        [Authorize]
        public async Task<ActionResult<GastosModel>> BuscarPorData(DateTime dataInicio, DateTime dataFim)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<GastosModel>> Insert([FromBody] GastosModel gastosModel)  //OK
        {
            GastosModel gastos = await _gastosRepository.Insert(gastosModel);

            if (gastos == null)
            {
                return BadRequest("Não foi possível incluir gasto!");
            }

            return Ok(gastos);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult<GastosModel>> Update(int id, [FromBody] GastosModel gastosModel)  //OK
        {
            gastosModel.Id = id;
            GastosModel gastos = await _gastosRepository.Update(gastosModel, id);

            if (gastos == null)
            {
                return BadRequest("Não foi possível alterar gasto!");
            }

            return Ok(gastos);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<GastosModel>> Delete(int id)  //OK
        {
            bool sucesso = await _gastosRepository.Delete(id);

            if (!sucesso)
            {
                return BadRequest("Não foi possível excluir gasto!");
            }

            return Ok(sucesso);
        }
    }
}
