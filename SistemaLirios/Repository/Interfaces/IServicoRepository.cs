using SistemaLirios.Models;

namespace SistemaLirios.Repository.Interfaces
{
    public interface IServicoRepository
    {
        Task<List<ServicoModel>> BuscarTodosServicos();
        Task<List<ServicoModel>> BuscarPorTipo(int tipo);

        Task<ServicoModel> Insert(ServicoModel Servico);
        Task<ServicoModel> Update(ServicoModel Servico, int id);

        Task<bool> Delete(int id);
    }
}
