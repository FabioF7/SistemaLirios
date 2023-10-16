using Microsoft.AspNetCore.Http;
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
        [HttpGet]
        public ActionResult<List<VendaModel>> BuscarTodosVendas()
        {
            return Ok();
        }
    }
}
