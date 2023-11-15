using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
        public async Task<ActionResult<List<TipoServicoModel>>> BuscarTodosTipoServicos()
        {
            throw new NotImplementedException();
        }


        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<TipoServicoModel>> BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<TipoServicoModel>> Insert([FromBody] TipoServicoModel tipoServico)
        {
            throw new NotImplementedException();
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult<TipoServicoModel>> Update(int id, [FromBody] TipoServicoModel tipoServico)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<TipoServicoModel>> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
