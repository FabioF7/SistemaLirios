using Microsoft.AspNetCore.Mvc;
using SistemaLirios.Models;
using SistemaLirios.Repository.Interfaces;

namespace SistemaLirios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrestadorController : ControllerBase
    {
        private readonly IPrestadorRepository _prestadorRepository;
        public PrestadorController(IPrestadorRepository prestadorRepository)
        {
            _prestadorRepository = prestadorRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<PrestadorModel>>> BuscarTodosPrestadores()
        {
            throw new NotImplementedException();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<PrestadorModel>> BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<ActionResult<PrestadorModel>> Insert([FromBody] PrestadorModel prestador)
        {
            throw new NotImplementedException();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PrestadorModel>> Update(int id, [FromBody] PrestadorModel prestador)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<PrestadorModel>> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
