using SistemaLirios.Models;
using SistemaLirios.Repository.Interfaces;

namespace SistemaLirios.Repository
{
    public class PrestadorRepository : IPrestadorRepository
    {
        public Task<PrestadorModel> BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<PrestadorModel>> BuscarTodosPrestadores()
        {
            throw new NotImplementedException();
        }     

        public Task<PrestadorModel> Insert(PrestadorModel Prestador)
        {
            throw new NotImplementedException();
        }

        public Task<PrestadorModel> Update(PrestadorModel Prestador, int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
