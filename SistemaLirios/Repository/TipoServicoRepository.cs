using SistemaLirios.Models;
using SistemaLirios.Repository.Interfaces;

namespace SistemaLirios.Repository
{
    public class TipoServicoRepository : ITipoServicoRepository
    {
        public Task<TipoServicoModel> BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<TipoServicoModel>> BuscarTodosTipoServicos()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<TipoServicoModel> Insert(TipoServicoModel TipoServico)
        {
            throw new NotImplementedException();
        }

        public Task<TipoServicoModel> Update(TipoServicoModel TipoServico, int id)
        {
            throw new NotImplementedException();
        }
    }
}
