using SistemaLirios.Models;

namespace SistemaLirios.Repository.Interfaces
{
    public interface IProdutoRepository
    {

        Task<List<ProdutoModel>> BuscarTodosProdutos();
        Task<ProdutoModel> BuscarPorId(int id);
        Task<List<ProdutoModel>> BuscarPorCategoria(int categoria);
        Task<List<ProdutoModel>> BuscarPorOrigem(int origem);
        Task<List<ProdutoModel>> BuscarPorData(DateTime dataInicio, DateTime dataFim);

        Task<ProdutoModel> Insert(ProdutoModel produto);
        Task<ProdutoModel> Update(ProdutoModel produto, int id);

        Task<bool> Delete(int id);

    }
}
