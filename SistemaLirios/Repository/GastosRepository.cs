using Microsoft.EntityFrameworkCore;
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
        public async Task<List<GastosModel>> BuscarTodosGastos()
        {
            return await _dbContext.Gastos.ToListAsync();
        }

        public async Task<GastosModel> BuscarPorId(int id)
        {
            return await _dbContext.Gastos.FirstOrDefaultAsync(x => x.Id == id) ?? throw new Exception($"Gasto {id} não encontrado no banco de dados");
        }
        public async Task<List<GastosModel>> BuscarPorData(DateTime dataInicio, DateTime dataFim)
        {
            return await _dbContext.Gastos.Where(x => x.DtCadastro >= dataInicio && x.DtCadastro <= dataFim).ToListAsync();
        }
        public async Task<GastosModel> Insert(GastosModel Gastos)
        {
            await _dbContext.Gastos.AddAsync(Gastos);
            await _dbContext.SaveChangesAsync();

            return Gastos;
        }
        public async Task<GastosModel> Update(GastosModel Gastos, int id)
        {
            GastosModel GastosPorId = await BuscarPorId(id);

            GastosPorId.NomeGasto = Gastos.NomeGasto;
            GastosPorId.Valor = Gastos.Valor;
            GastosPorId.Recorrente = Gastos.Recorrente;
            GastosPorId.DtAlteracao = Gastos.DtAlteracao;
            GastosPorId.AlteradoPor = Gastos.AlteradoPor;


            _dbContext.Gastos.Update(GastosPorId);
            await _dbContext.SaveChangesAsync();

            return GastosPorId;
        }
        public async Task<bool> Delete(int id)
        {
            GastosModel GastosPorId = await BuscarPorId(id);

            _dbContext.Gastos.Remove(GastosPorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
