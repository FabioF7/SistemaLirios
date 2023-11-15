using Microsoft.EntityFrameworkCore;
using SistemaLirios.Data;
using SistemaLirios.Models;
using SistemaLirios.Repository.Interfaces;

namespace SistemaLirios.Repository
{
    public class OrigemRepository : IOrigemRepository
    {
        private readonly SistemaLiriosDBContext _dbContext;

        public OrigemRepository(SistemaLiriosDBContext sistemaLirioDBContext)
        {
            _dbContext = sistemaLirioDBContext;
        }
        public async Task<List<OrigemModel>> BuscarTodasOrigens()
        {
            return await _dbContext.Origem.ToListAsync();
        }

        public async Task<OrigemModel> BuscarPorId(int id)
        {
            return await _dbContext.Origem.FirstOrDefaultAsync(x => x.Id == id) ?? throw new Exception($"Origem {id} não encontrado no banco de dados");
        }

        public async Task<OrigemModel> Insert(OrigemModel Origem)
        {
            await _dbContext.Origem.AddAsync(Origem);
            await _dbContext.SaveChangesAsync();

            return Origem;
        }

        public async Task<OrigemModel> Update(OrigemModel Origem, int id)
        {
            OrigemModel origemPorId = await BuscarPorId(id);

            origemPorId.Nome = Origem.Nome;
            origemPorId.Ativo = Origem.Ativo;
            origemPorId.DtAlteracao = Origem.DtAlteracao;
            origemPorId.AlteradoPor = Origem.AlteradoPor;

            _dbContext.Origem.Update(origemPorId);
            await _dbContext.SaveChangesAsync();

            return origemPorId;
        }

        public async Task<bool> Delete(int id)
        {
            OrigemModel origemPorId = await BuscarPorId(id);

            _dbContext.Origem.Remove(origemPorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
