using Microsoft.EntityFrameworkCore;
using SistemaLirios.Data;
using SistemaLirios.Models;
using SistemaLirios.Repository.Interfaces;

namespace SistemaLirios.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly SistemaLiriosDBContext _dbContext;

        public UsuarioRepository(SistemaLiriosDBContext sistemaLirioDBContext)
        {
            _dbContext = sistemaLirioDBContext;
        }

        public async Task<UsuarioModel> BuscarPorId(int id)
        {
            return await _dbContext.Usuario.FirstOrDefaultAsync(x => x.UserID == id) ?? throw new Exception($"Usuario {id} não encontrado no banco de dados");
        }     

        public async Task<UsuarioModel> Insert(UsuarioModel Usuario)
        {
            await _dbContext.Usuario.AddAsync(Usuario);
            await _dbContext.SaveChangesAsync();

            return Usuario;
        }

        public async Task<UsuarioModel> Update(UsuarioModel Usuario, int id)
        {
            UsuarioModel usuarioPorId = await BuscarPorId(id);

            usuarioPorId.Nome = Usuario.Nome;
            usuarioPorId.Usuario = Usuario.Usuario;
            usuarioPorId.PasswordHash = Usuario.PasswordHash;
            usuarioPorId.PasswordSalt = Usuario.PasswordSalt;
            usuarioPorId.DtAlteracao = Usuario.DtAlteracao;
            usuarioPorId.Ativo = Usuario.Ativo;
            usuarioPorId.IdPerfil = Usuario.IdPerfil;

            _dbContext.Usuario.Update(usuarioPorId);
            await _dbContext.SaveChangesAsync();

            return usuarioPorId;
        }

        public async Task<bool> Delete(int id)
        {
            UsuarioModel usuarioPorId = await BuscarPorId(id);

            _dbContext.Usuario.Remove(usuarioPorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
