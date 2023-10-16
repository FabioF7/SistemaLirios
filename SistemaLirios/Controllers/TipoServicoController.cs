using Microsoft.AspNetCore.Mvc;
using SistemaLirios.Models;
using SistemaLirios.Repository.Interfaces;

namespace SistemaLirios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoServicoController : ControllerBase
    {
        private readonly ITipoServicoRepository _tipoServicoRepository;
        public TipoServicoController(ITipoServicoRepository tipoServicoRepository)
        {
            _tipoServicoRepository = tipoServicoRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<TipoServicoModel>>> BuscarTodosTipoServicos()
        {
            throw new NotImplementedException();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<TipoServicoModel>> BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<ActionResult<TipoServicoModel>> Insert([FromBody] TipoServicoModel tipoServico)
        {
            throw new NotImplementedException();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TipoServicoModel>> Update(int id, [FromBody] TipoServicoModel tipoServico)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TipoServicoModel>> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
