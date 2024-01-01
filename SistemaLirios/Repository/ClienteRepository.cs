using Microsoft.EntityFrameworkCore;
using SistemaLirios.Data;
using SistemaLirios.Models;
using SistemaLirios.Repository.Interfaces;
using System.Linq;

namespace SistemaLirios.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly SistemaLiriosDBContext _dbContext;

        public ClienteRepository(SistemaLiriosDBContext sistemaLirioDBContext)
        {
            _dbContext = sistemaLirioDBContext;
        }

        public async Task<List<ClienteModel>> BuscarTodosClientes()
        {
            return await _dbContext.Cliente.ToListAsync();
        }

        public async Task<ClienteModel> BuscarPorId(int id)
        {
            return await _dbContext.Cliente.FirstOrDefaultAsync(x => x.Id == id) ?? throw new Exception($"Cliente {id} não encontrado no banco de dados");
        }     

        public async Task<ClienteModel> Insert(ClienteModel Cliente)
        {
            await _dbContext.Cliente.AddAsync(Cliente);
            await _dbContext.SaveChangesAsync();

            return Cliente;
        }

        public async Task<ClienteModel> Update(ClienteModel Cliente, int id)
        {
            ClienteModel clientePorId = await BuscarPorId(id);

            clientePorId.Nome = Cliente.Nome;
            clientePorId.Email = Cliente.Email;
            clientePorId.Celular = Cliente.Celular;
            clientePorId.CEP = Cliente.CEP;
            clientePorId.Endereco = Cliente.Endereco;
            clientePorId.DtNascimento = Cliente.DtNascimento;
            clientePorId.Sexo = Cliente.Sexo;
            clientePorId.Indicacao = Cliente.Indicacao;
            clientePorId.Bloqueado = Cliente.Bloqueado;
            clientePorId.AlteradoPor = Cliente.AlteradoPor;
            clientePorId.DtAlteracao = Cliente.DtAlteracao;


            _dbContext.Cliente.Update(clientePorId);
            await _dbContext.SaveChangesAsync();

            return clientePorId;
        }

        public async Task<bool> Delete(int id)
        {
            ClienteModel clientePorId = await BuscarPorId(id);

            _dbContext.Cliente.Remove(clientePorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<ClienteModel> BuscarPorNome(string NomeCliente)
        {
            return await _dbContext.Cliente.FirstOrDefaultAsync(x => x.Nome == NomeCliente) ?? throw new Exception($"Cliente {NomeCliente} não encontrado no banco de dados");
        }

        public async Task<List<ClienteModel>> BuscarPorInadimplencia()
        {
            return await _dbContext.Cliente.Where(x => x.Inadimplencia == 1).ToListAsync() ?? throw new Exception($"Não foram encontrados Clientes Inadimplentes");
        }
    }
}
