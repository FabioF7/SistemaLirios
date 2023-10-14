using SistemaLirios.Data;
using SistemaLirios.Models;
using SistemaLirios.Repository.Interfaces;

namespace SistemaLirios.Repository
{
    public class GastosRepository : IGastosRepository
    {

        private readonly SistemaLiriosDBContext _dbContext;

        public GastosRepository(SistemaLiriosDBContext sistemaLirioDBContext)
        {
            _dbContext = sistemaLirioDBContext;
        }
        public Task<List<GastosModel>> BuscarTodosGastos()
        {
            throw new NotImplementedException();
        }
        public Task<List<GastosModel>> BuscarPorData(DateTime dataInicio, DateTime dataFim)
        {
            throw new NotImplementedException();
        }
        public Task<GastosModel> Insert(GastosModel Gastos)
        {
            throw new NotImplementedException();
        }
        public Task<GastosModel> Update(GastosModel Gastos, int id)
        {
            throw new NotImplementedException();
        }
        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
