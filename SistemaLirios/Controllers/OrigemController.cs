using Microsoft.AspNetCore.Mvc;
using SistemaLirios.Models;
using SistemaLirios.Repository.Interfaces;

namespace SistemaLirios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrigemController : ControllerBase
    {
        private readonly IOrigemRepository _origemRepository;
        public OrigemController(IOrigemRepository origemRepository)
        {
            _origemRepository = origemRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<OrigemModel>>> BuscarTodasOrigens()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<ActionResult<OrigemModel>> Insert([FromBody] OrigemModel origem)
        {
            throw new NotImplementedException();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<OrigemModel>> Update(int id, [FromBody] OrigemModel origem)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<OrigemModel>> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
