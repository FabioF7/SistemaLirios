using SistemaLirios.Models;

namespace SistemaLirios.Repository.Interfaces
{
    public interface IPerfilRepository
    {
        Task<List<PerfilModel>> BuscarTodosPerfis();
        Task<PerfilModel> BuscarPorId(int id);

        Task<PerfilModel> Insert(PerfilModel Perfil);
        Task<PerfilModel> Update(PerfilModel Perfil, int id);
        Task<bool> Delete(int id);
    }
}
