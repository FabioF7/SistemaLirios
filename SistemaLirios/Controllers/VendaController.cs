using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaLirios.Models;

namespace SistemaLirios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendaController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<ProdutoModel>> BuscarTodosVendas()
        {
            return Ok();
        }
    }
}
