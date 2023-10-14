using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaLirios.Models;
using SistemaLirios.Repository;
using SistemaLirios.Repository.Interfaces;

namespace SistemaLirios.Controllers
{
    public class GastosController
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

        
        [HttpGet("BuscarPorData")]
        public async Task<ActionResult<GastosModel>> BuscarPorData(DateTime dataInicio, DateTime dataFim)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<ActionResult<GastosModel>> Insert([FromBody] GastosModel gastos)
        {
            throw new NotImplementedException();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<GastosModel>> Update([FromBody] GastosModel gastos, int id)
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
