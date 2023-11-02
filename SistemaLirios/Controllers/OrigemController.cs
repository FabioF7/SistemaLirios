using Microsoft.AspNetCore.Mvc;
using SistemaLirios.Models;
using SistemaLirios.Repository;
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
            List<OrigemModel> origem = await _origemRepository.BuscarTodasOrigens();
            return Ok(origem);
        }

        [HttpPost]
        public async Task<ActionResult<OrigemModel>> Insert([FromBody] OrigemModel origemModel)
        {
            OrigemModel origem = await _origemRepository.Insert(origemModel);
            return Ok(origem);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<OrigemModel>> Update(int id, [FromBody] OrigemModel origemModel)
        {
            origemModel.Id = id;
            OrigemModel origem = await _origemRepository.Update(origemModel, id);
            return Ok(origem);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<OrigemModel>> Delete(int id)
        {
            bool sucesso = await _origemRepository.Delete(id);
            return Ok(sucesso);
        }
    }
}
