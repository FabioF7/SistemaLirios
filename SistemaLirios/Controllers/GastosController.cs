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
        public async Task<ActionResult<List<GastosModel>>> BuscarTodosGastos()  //OK
        {
            List<GastosModel> clientes = await _gastosRepository.BuscarTodosGastos();
            return Ok(clientes);
        }


        [HttpGet("{Data}")]
        public async Task<ActionResult<GastosModel>> BuscarPorData(DateTime Data)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<ActionResult<GastosModel>> Insert([FromBody] GastosModel gastosModel)  //OK
        {
            GastosModel gastos = await _gastosRepository.Insert(gastosModel);
            return Ok(gastos);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<GastosModel>> Update(int id, [FromBody] GastosModel gastosModel)  //OK
        {
            gastosModel.Id = id;
            GastosModel gastos = await _gastosRepository.Update(gastosModel, id);
            return Ok(gastos);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<GastosModel>> Delete(int id)  //OK
        {
            bool sucesso = await _gastosRepository.Delete(id);
            return Ok(sucesso);
        }
    }
}
