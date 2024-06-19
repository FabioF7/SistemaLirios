using Microsoft.EntityFrameworkCore;
using SistemaLirios.Data;
using SistemaLirios.Models;
using SistemaLirios.Repository.Interfaces;

namespace SistemaLirios.Repository
{
    public class InventarioRepository : IInventarioRepository
    {
        private readonly SistemaLiriosDBContext _dbContext;

        public InventarioRepository(SistemaLiriosDBContext sistemaLirioDBContext)
        {
            _dbContext = sistemaLirioDBContext;
        }

        public async Task<List<InventarioModel>> BuscarTodosInventarios()
        {
            return await _dbContext.Inventario.ToListAsync();
        }

        public async Task<InventarioModel> BuscarPorId(int id)
        {
            return await _dbContext.Inventario.FirstOrDefaultAsync(x => x.Id == id) ?? throw new Exception($"Inventario {id} não encontrado no banco de dados");
        }     

        public async Task<InventarioModel> Insert(InventarioModel Inventario)
        {
            await _dbContext.Inventario.AddAsync(Inventario);
            await _dbContext.SaveChangesAsync();

            return Inventario;
        }

        public async Task<InventarioModel> Update(InventarioModel Inventario, int id)
        {
            try
            {
                InventarioModel InventarioPorId = await BuscarPorId(id);

                InventarioPorId.Nome = Inventario.Nome;

                _dbContext.Inventario.Update(InventarioPorId);
                await _dbContext.SaveChangesAsync();

                return InventarioPorId;
            }
            catch (Exception ex)
            {
                InventarioModel InventarioPorI = new InventarioModel();
                return InventarioPorI;
            }
        }

        public async Task<bool> Delete(int id)
        {
            InventarioModel InventarioPorId = await BuscarPorId(id);

            _dbContext.Inventario.Remove(InventarioPorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
