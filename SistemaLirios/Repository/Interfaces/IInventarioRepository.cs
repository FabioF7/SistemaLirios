using SistemaLirios.Models;

namespace SistemaLirios.Repository.Interfaces
{
    public interface IInventarioRepository
    {

        Task<List<InventarioModel>> BuscarTodosInventarios();
        Task<InventarioModel> BuscarPorId(int id);
        Task<InventarioModel> Insert(InventarioModel Inventario);
        Task<InventarioModel> Update(InventarioModel Inventario, int id);

        Task<bool> Delete(int id);

    }
}
