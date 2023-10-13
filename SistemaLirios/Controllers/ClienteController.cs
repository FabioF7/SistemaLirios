using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaLirios.Models;
using SistemaLirios.Repository;
using SistemaLirios.Repository.Interfaces;

namespace SistemaLirios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteRepository _clienteRepository;
        public ClienteController(IClienteRepository clienteRepository) 
        {
            _clienteRepository = clienteRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProdutoModel>>> BuscarTodosClientes()
        {
            List<ClienteModel> clientes = await _clienteRepository.BuscarTodosClientes();
            return Ok(clientes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProdutoModel>> BuscarPorId(int id)
        {
            ClienteModel cliente = await _clienteRepository.BuscarPorId(id);
            return Ok(cliente);
        }

        [HttpPost]
        public async Task<ActionResult<ProdutoModel>> Insert([FromBody] ClienteModel clienteModel)
        {
            ClienteModel cliente = await _clienteRepository.Insert(clienteModel);
            return Ok(cliente);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProdutoModel>> Update([FromBody] ClienteModel clienteModel, int id)
        {
            clienteModel.Id = id;
            ClienteModel cliente = await _clienteRepository.Update(clienteModel, id);
            return Ok(cliente);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ProdutoModel>> Delete(int id)
        {
            bool sucesso = await _clienteRepository.Delete(id);
            return Ok(sucesso);
        }
    }
}
