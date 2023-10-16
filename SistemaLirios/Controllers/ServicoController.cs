using Microsoft.AspNetCore.Mvc;
using SistemaLirios.Models;
using SistemaLirios.Repository;
using SistemaLirios.Repository.Interfaces;

namespace SistemaLirios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicoController : ControllerBase
    {
        private readonly IServicoRepository _servicoRepository;
        public ServicoController(IServicoRepository servicoRepository)
        {
            _servicoRepository = servicoRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<ServicoModel>>> BuscarTodosServicos()
        {
            throw new NotImplementedException();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<ServicoModel>> BuscarPorTipo(int tipo)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<ActionResult<ServicoModel>> Insert([FromBody] ServicoModel servico)
        {
            throw new NotImplementedException();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ServicoModel>> Update(int id, [FromBody] ServicoModel servico)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServicoModel>> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
