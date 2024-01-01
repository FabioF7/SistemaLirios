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

        [HttpGet("Todos")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<ClienteModel>>> BuscarTodosClientes()  //OK
        {
            try
            {            
                List<ClienteModel> clientes = await _clienteRepository.BuscarTodosClientes();

                if (clientes == null)
                {
                    return BadRequest("Nenhum Cliente encontrado!");
                }

                return Ok(clientes);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um Erro: {ex}");
            }
        }

        [HttpGet("{Nome}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<ClienteModel>> BuscarPorNome(string Nome)  //OK
        {
            try
            {
                ClienteModel cliente = await _clienteRepository.BuscarPorNome(Nome);

                if (cliente == null)
                {
                    return BadRequest("Nenhum Cliente encontrado!");
                }

                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um Erro: {ex}");
            }
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<ClienteModel>>> BuscarPorInadimplencia()  //OK
        {
            try
            {
                List<ClienteModel> clientes = await _clienteRepository.BuscarPorInadimplencia();

                if (clientes == null)
                {

                    return BadRequest("Nenhum Cliente encontrado!");
                }

                return Ok(clientes);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um Erro: {ex}");
            }
        }

        [HttpGet("{id}")]
        [Authorize (Roles = "Admin")]
        public async Task<ActionResult<ClienteModel>> BuscarPorId(int id)  //OK
        {
            try
            {
                ClienteModel cliente = await _clienteRepository.BuscarPorId(id);

                if (cliente == null)
                {
                    return BadRequest("Cliente não encontrado!");
                }

                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um Erro: {ex}");
            }
        }

        [HttpPost]
        [Authorize (Roles = "Admin")]
        public async Task<ActionResult<ClienteModel>> Insert([FromBody] ClienteModel clienteModel)  //OK
        {
            try
            {
                ClienteModel cliente = await _clienteRepository.Insert(clienteModel);

                if (cliente == null)
                {
                    return BadRequest("Não foi possível incluir cliente!");
                }

                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um Erro: {ex}");
            }
        }

        [HttpPut("{id}")]
        [Authorize (Roles = "Admin")]
        public async Task<ActionResult<ClienteModel>> Update(int id, [FromBody] ClienteModel clienteModel)  //OK
        {
            try
            {
                clienteModel.Id = id;
                ClienteModel cliente = await _clienteRepository.Update(clienteModel, id);

                if (cliente == null)
                {
                    return BadRequest("Não foi possível alterar cliente!");
                }

                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um Erro: {ex}");
            }
        }

        [HttpDelete("{id}")]
        [Authorize (Roles = "Admin")]
        public async Task<ActionResult<ClienteModel>> Delete(int id)  //OK
        {
            try
            {
                bool sucesso = await _clienteRepository.Delete(id);

                if (!sucesso)
                {
                    return BadRequest("Não foi possível excluir cliente!");
                }

                return Ok(sucesso);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um Erro: {ex}");
            }
        }
    }
}
