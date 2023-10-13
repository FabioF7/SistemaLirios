using SistemaLirios.Models;

namespace SistemaLirios.Repository.Interfaces
{
    public interface IVendaRepository
    {
        Task<List<VendaModel>> BuscarTodosVendas();
        Task<List<VendaModel>> BuscarPorId(int id);
        Task<List<VendaModel>> BuscarPorCliente(int idCliente);

        Task<VendaModel> Insert(VendaModel Venda);
        Task<VendaModel> Update(VendaModel Venda, int id);

        Task<bool> Delete(int id);
    }
}
