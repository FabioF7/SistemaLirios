using SistemaLirios.Models;

namespace SistemaLirios.Repository.Interfaces
{
    public interface ITipoServicoRepository
    {
        Task<List<TipoServicoModel>> BuscarTodosTipoServicos();
        Task<TipoServicoModel> BuscarPorId(int id);

        Task<TipoServicoModel> Insert(TipoServicoModel TipoServico);
        Task<TipoServicoModel> Update(TipoServicoModel TipoServico, int id);

        Task<bool> Delete(int id);
    }
}
