using Microsoft.EntityFrameworkCore;
using SistemaLirios.Data;
using SistemaLirios.Models;
using SistemaLirios.Repository.Interfaces;
using System.Web.Http.Results;

namespace SistemaLirios.Repository
{
    public class InventarioDetallhesRepository : IInventarioDetallhesRepository
    {
        private readonly SistemaLiriosDBContext _dbContext;

        public InventarioDetallhesRepository(SistemaLiriosDBContext sistemaLirioDBContext)
        {
            _dbContext = sistemaLirioDBContext;
        }

        public async Task<List<InventarioDetalhesModel>> BuscarTodosItensInventarioPorId(int idInventario)
        {
            return await _dbContext.InventarioDetalhes.Where(i => i.IdInventario == idInventario).ToListAsync();
        }

        public async Task<InventarioDetalhesModel> BuscarPorId(int id)
        {
            return await _dbContext.InventarioDetalhes.FirstOrDefaultAsync(x => x.Id == id) ?? throw new Exception($"Inventario {id} não encontrado no banco de dados");
        }

        public async Task<List<InventarioDetalhesModel>> Insert(List<InventarioDetalhesModel> InventarioDetalhes)
        {
            foreach (var detalhe in InventarioDetalhes)
            {
                await _dbContext.InventarioDetalhes.AddAsync(detalhe);
                await _dbContext.SaveChangesAsync();
            }

            return InventarioDetalhes;
        }

        public async Task<InventarioDetalhesModel> Update(InventarioDetalhesModel InventarioDetalhes, int id)
        {
            try
            {
                InventarioDetalhesModel InventarioDetalhesPorId = await BuscarPorId(id);

                _dbContext.InventarioDetalhes.Update(InventarioDetalhesPorId);
                await _dbContext.SaveChangesAsync();

                return InventarioDetalhesPorId;
            }
            catch (Exception ex)
            {
                InventarioDetalhesModel InventarioDetalhesPorId = new InventarioDetalhesModel();
                return InventarioDetalhesPorId;
            }
        }

        public Task<List<InventarioDetalhesModel>> UpdateAll(List<InventarioDetalhesModel> InventarioDetalhes, int idInventario)
        {
            throw new NotImplementedException();

            //try
            //{
            //    InventarioDetalhesModel InventarioDetalhesPorId = await BuscarPorId(id);

            //    _dbContext.InventarioDetalhes.Update(InventarioDetalhesPorId);
            //    await _dbContext.SaveChangesAsync();

            //    return InventarioDetalhesPorId;
            //}
            //catch (Exception ex)
            //{
            //    InventarioDetalhesModel InventarioDetalhesPorId = new InventarioDetalhesModel();
            //    return InventarioDetalhesPorId;
            //}
        }

        public async Task<bool> Delete(int id)
        {
            InventarioDetalhesModel InventarioPorId = await BuscarPorId(id);

            _dbContext.InventarioDetalhes.Remove(InventarioPorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }

    }
}
