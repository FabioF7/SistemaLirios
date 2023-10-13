using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaLirios.Models;

namespace SistemaLirios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<ProdutoModel>> BuscarTodosProdutos()
        {
            return Ok();
        }
    }
}
