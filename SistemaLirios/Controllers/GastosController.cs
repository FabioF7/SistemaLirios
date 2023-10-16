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
        public async Task<ActionResult<List<GastosModel>>> BuscarTodosGastos()
        {
            throw new NotImplementedException();
        }


        [HttpGet("{Data}")]
        public async Task<ActionResult<GastosModel>> BuscarPorData(DateTime Data)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<ActionResult<GastosModel>> Insert([FromBody] GastosModel gastos)
        {
            throw new NotImplementedException();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<GastosModel>> Update(int id, [FromBody] GastosModel gastos)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<GastosModel>> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
