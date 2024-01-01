using SistemaLirios.Models;

namespace SistemaLirios.Repository.Interfaces
{
    public interface IClienteRepository
    {

        Task<List<ClienteModel>> BuscarTodosClientes();
        Task<ClienteModel> BuscarPorId(int id);
        Task<ClienteModel> BuscarPorNome(string NomeCliente);
        Task<List<ClienteModel>> BuscarPorInadimplencia();
        Task<ClienteModel> Insert(ClienteModel Cliente);
        Task<ClienteModel> Update(ClienteModel Cliente, int id);

        Task<bool> Delete(int id);

    }
}
