using Microsoft.EntityFrameworkCore;
using SistemaLirios.Data;
using SistemaLirios.Models;
using SistemaLirios.Repository.Interfaces;

namespace SistemaLirios.Repository
{
    public class PrestadorRepository : IPrestadorRepository
    {

        private readonly SistemaLiriosDBContext _dbContext;

        public PrestadorRepository(SistemaLiriosDBContext sistemaLirioDBContext)
        {
            _dbContext = sistemaLirioDBContext;
        }
        public async Task<List<PrestadorModel>> BuscarTodosPrestadores()
        {
            return await _dbContext.Prestador.ToListAsync();
        }

        public async Task<PrestadorModel> BuscarPorId(int id)
        {
            return await _dbContext.Prestador.FirstOrDefaultAsync(x => x.Id == id) ?? throw new Exception($"Prestador {id} não encontrado no banco de dados");
        }

        public async Task<PrestadorModel> Insert(PrestadorModel Prestador)
        {
            await _dbContext.Prestador.AddAsync(Prestador);
            await _dbContext.SaveChangesAsync();

            return Prestador;
        }

        public async Task<PrestadorModel> Update(PrestadorModel Prestador, int id)
        {
            PrestadorModel prestadorPorId = await BuscarPorId(id);

            prestadorPorId.Nome = Prestador.Nome;
            prestadorPorId.TipoServicoId = Prestador.TipoServicoId;
            prestadorPorId.TipoServico = Prestador.TipoServico;
            prestadorPorId.Local = Prestador.Local;
            prestadorPorId.Ativo = Prestador.Ativo;
            prestadorPorId.DtAlteracao = Prestador.DtAlteracao;
            prestadorPorId.AlteradoPor = Prestador.AlteradoPor;

            _dbContext.Prestador.Update(prestadorPorId);
            await _dbContext.SaveChangesAsync();

            return prestadorPorId;
        }

        public async Task<bool> Delete(int id)
        {
            PrestadorModel prestadorPorId = await BuscarPorId(id);

            _dbContext.Prestador.Remove(prestadorPorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
