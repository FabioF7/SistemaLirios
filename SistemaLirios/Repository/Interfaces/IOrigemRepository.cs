using SistemaLirios.Models;

namespace SistemaLirios.Repository.Interfaces
{
    public interface IOrigemRepository
    {
        Task<List<OrigemModel>> BuscarTodasOrigens();

        Task<OrigemModel> Insert(OrigemModel Origem);

        Task<OrigemModel> Update(OrigemModel Origem, int id);

        Task<bool> Delete(int id);
    }
}
