using Microsoft.EntityFrameworkCore;
using SistemaLirios.Data;
using SistemaLirios.Models;
using SistemaLirios.Repository.Interfaces;

namespace SistemaLirios.Repository
{
    public class PerfilRepository : IPerfilRepository
    {
        private readonly SistemaLiriosDBContext _dbContext;

        public PerfilRepository(SistemaLiriosDBContext sistemaLirioDBContext)
        {
            _dbContext = sistemaLirioDBContext;
        }

        public async Task<List<PerfilModel>> BuscarTodosPerfis()
        {
            return await _dbContext.Perfil.ToListAsync();
        }

        public async Task<PerfilModel> BuscarPorId(int id)
        {
            return await _dbContext.Perfil.FirstOrDefaultAsync(x => x.Id == id) ?? throw new Exception($"Perfil {id} não encontrado no banco de dados");
        }     

        public async Task<PerfilModel> Insert(PerfilModel perfil)
        {
            await _dbContext.Perfil.AddAsync(perfil);
            await _dbContext.SaveChangesAsync();

            return perfil;
        }

        public async Task<PerfilModel> Update(PerfilModel perfil, int id)
        {
            PerfilModel perfilPorId = await BuscarPorId(id);

            perfilPorId.NomePerfil = perfil.NomePerfil;
            perfilPorId.DescricaoPerfil = perfil.DescricaoPerfil;
            perfilPorId.Ativo = perfil.Ativo;
            perfilPorId.DtAlteracao = perfil.DtAlteracao;

            _dbContext.Perfil.Update(perfilPorId);
            await _dbContext.SaveChangesAsync();

            return perfilPorId;
        }

        public async Task<bool> Delete(int id)
        {
            PerfilModel perfilPorId = await BuscarPorId(id);

            _dbContext.Perfil.Remove(perfilPorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
