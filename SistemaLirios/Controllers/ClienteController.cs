using Microsoft.AspNetCore.Authorization;
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
        [Authorize (Roles = "Admin")]
        public async Task<ActionResult<List<ClienteModel>>> BuscarTodosClientes()  //OK
        {
            List<ClienteModel> clientes = await _clienteRepository.BuscarTodosClientes();

            if(clientes == null)
            {
                return BadRequest("Nenhum Cliente encontrado!");
            }

            return Ok(clientes);
        }

        [HttpGet("{id}")]
        [Authorize (Roles = "Admin")]
        public async Task<ActionResult<ClienteModel>> BuscarPorId(int id)  //OK
        {
            ClienteModel cliente = await _clienteRepository.BuscarPorId(id);

            if (cliente == null)
            {
                return BadRequest("Cliente não encontrado!");
            }

            return Ok(cliente);
        }

        [HttpPost]
        [Authorize (Roles = "Admin")]
        public async Task<ActionResult<ClienteModel>> Insert([FromBody] ClienteModel clienteModel)  //OK
        {
            ClienteModel cliente = await _clienteRepository.Insert(clienteModel);

            if (cliente == null)
            {
                return BadRequest("Não foi possível incluir cliente!");
            }

            return Ok(cliente);
        }

        [HttpPut("{id}")]
        [Authorize (Roles = "Admin")]
        public async Task<ActionResult<ClienteModel>> Update(int id, [FromBody] ClienteModel clienteModel)  //OK
        {
            clienteModel.Id = id;
            ClienteModel cliente = await _clienteRepository.Update(clienteModel, id);

            if (cliente == null)
            {
                return BadRequest("Não foi possível alterar cliente!");
            }

            return Ok(cliente);
        }

        [HttpDelete("{id}")]
        [Authorize (Roles = "Admin")]
        public async Task<ActionResult<ClienteModel>> Delete(int id)  //OK
        {
            bool sucesso = await _clienteRepository.Delete(id);

            if (!sucesso)
            {
                return BadRequest("Não foi possível excluir cliente!");
            }

            return Ok(sucesso);
        }
    }
}
