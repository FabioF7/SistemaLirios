using SistemaLirios.Models;
using SistemaLirios.Repository.Interfaces;

namespace SistemaLirios.Repository
{
    public class ServicoRepository : IServicoRepository
    {
        public Task<List<ServicoModel>> BuscarPorTipo(int tipo)
        {
            throw new NotImplementedException();
        }

        public Task<List<ServicoModel>> BuscarTodosServicos()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServicoModel> Insert(ServicoModel Servico)
        {
            throw new NotImplementedException();
        }

        public Task<ServicoModel> Update(ServicoModel Servico, int id)
        {
            throw new NotImplementedException();
        }
    }
}
