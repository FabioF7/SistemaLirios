using SistemaLirios.Models;

namespace SistemaLirios.Repository.Interfaces
{
    public interface IPrestadorRepository
    {
        Task<List<PrestadorModel>> BuscarTodosPrestadores();
        Task<PrestadorModel> BuscarPorId(int id);

        Task<PrestadorModel> Insert(PrestadorModel Prestador);
        Task<PrestadorModel> Update(PrestadorModel Prestador, int id);

        Task<bool> Delete(int id);
    }
}
