using SistemaLirios.Models;
using SistemaLirios.Repository.Interfaces;

namespace SistemaLirios.Repository
{
    public class OrigemRepository : IOrigemRepository
    {
        public Task<List<OrigemModel>> BuscarTodasOrigens()
        {
            throw new NotImplementedException();
        }

        public Task<OrigemModel> Insert(OrigemModel Origem)
        {
            throw new NotImplementedException();
        }

        public Task<OrigemModel> Update(OrigemModel Origem, int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
