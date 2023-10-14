using Microsoft.AspNetCore.Mvc;
using SistemaLirios.Models;
using SistemaLirios.Repository;
using SistemaLirios.Repository.Interfaces;

namespace SistemaLirios.Controllers
{
    public class ServicoController
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
        public async Task<ActionResult<ServicoModel>> Update([FromBody] ServicoModel servico, int id)
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
