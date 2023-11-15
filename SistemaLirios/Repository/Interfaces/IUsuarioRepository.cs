using SistemaLirios.Models;

namespace SistemaLirios.Repository.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<UsuarioModel> BuscarPorId(int id);
        Task<UsuarioModel> Insert(UsuarioModel Usuario);
        Task<UsuarioModel> Update(UsuarioModel Usuario, int id);
        Task<bool> Delete(int id);

    }
}
