using SistemaLirios.Models;
using SistemaLirios.Repository.Interfaces;

namespace SistemaLirios.Repository
{
    public class VendaRepository : IVendaRepository
    {
        public Task<List<VendaModel>> BuscarPorCliente(int idCliente)
        {
            throw new NotImplementedException();
        }

        public Task<List<VendaModel>> BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<VendaModel>> BuscarTodosVendas()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<VendaModel> Insert(VendaModel Venda)
        {
            throw new NotImplementedException();
        }

        public Task<VendaModel> Update(VendaModel Venda, int id)
        {
            throw new NotImplementedException();
        }
    }
}
