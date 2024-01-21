using SistemaLirios.Models;

namespace SistemaLirios.Repository.Interfaces
{
    public interface IVendaRepository
    {
        Task<List<VendaModel>> BuscarTodosVendas();
        Task<VendaModel> BuscarPorId(int id);
        Task<List<VendaModel>> BuscarPorIdCliente(int id);

        Task<List<VendaModel>> Insert(List<VendaModel> vendas);
        Task<VendaModel> Update(VendaModel Venda, int id);

        Task<bool> Delete(int id);
    }
}
