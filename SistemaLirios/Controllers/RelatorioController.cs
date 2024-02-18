using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaLirios.Models;
using SistemaLirios.Repository.Interfaces;

namespace SistemaLirios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RelatorioController : ControllerBase
    {
        private readonly IRelatorioRepository _relatorioRepository;

        public RelatorioController(IRelatorioRepository relatorioRepository) 
        {
            _relatorioRepository = relatorioRepository;
        }

        [HttpGet("Historico/{id}")]
        [Authorize (Roles = "Admin")]
        public async Task<ActionResult<List<HistoricoModel>>> RetornaHistorico(int id)
        {
            try
            {
                List<HistoricoModel> historico = await _relatorioRepository.RetornaHistorico(id);

                if (historico == null)
                {
                    return BadRequest("Não foi possível gerar o Historico!");
                }

                return Ok(historico);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um Erro: {ex}");
            }
        }

    }
}
