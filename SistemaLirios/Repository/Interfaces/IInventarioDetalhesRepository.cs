using SistemaLirios.Models;
using System.Collections.Generic;

namespace SistemaLirios.Repository.Interfaces
{
    public interface IInventarioDetallhesRepository
    {

        Task<List<InventarioDetalhesModel>> BuscarTodosItensInventarioPorId(int idInventario);

        Task<InventarioDetalhesModel> BuscarPorId(int id);

        Task<List<InventarioDetalhesModel>> Insert(List<InventarioDetalhesModel> InventarioDetalhes);

        Task<InventarioDetalhesModel> Update(InventarioDetalhesModel InventarioDetalhes, int id);

        Task<List<InventarioDetalhesModel>> UpdateAll(List<InventarioDetalhesModel> InventarioDetalhes, int idInventario);

        Task<bool> Delete(int id);

    }
}
