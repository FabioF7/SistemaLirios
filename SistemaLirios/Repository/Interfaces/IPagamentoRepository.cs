using SistemaLirios.Models;

namespace SistemaLirios.Repository.Interfaces
{
    public interface IPagamentoRepository
    {
        Task<List<PagamentoModel>> BuscarTodosPagamentos();
        Task<PagamentoModel> BuscarPorId(int id);
        Task<List<PagamentoModel>> BuscarPorIdCliente(int id);

        Task<double> RetornaDivida(List<PagamentoModel> pagamento, List<VendaModel> venda);

        Task<PagamentoModel> Insert(PagamentoModel pagamento);
        Task<PagamentoModel> Update(PagamentoModel pagamento, int id);

        Task<bool> Delete(int id);
    }
}
