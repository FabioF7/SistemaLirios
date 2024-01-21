using Microsoft.EntityFrameworkCore;
using SistemaLirios.Data;
using SistemaLirios.Enums;
using SistemaLirios.Models;
using SistemaLirios.Repository.Interfaces;

namespace SistemaLirios.Repository
{
    public class VendaRepository : IVendaRepository
    {

        private readonly SistemaLiriosDBContext _dbContext;

        public VendaRepository(SistemaLiriosDBContext sistemaLirioDBContext)
        {
            _dbContext = sistemaLirioDBContext;
        }

        public async Task<List<VendaModel>> BuscarTodosVendas()
        {
            return await _dbContext.Venda.ToListAsync();
        }

        public async Task<VendaModel> BuscarPorId(int id)
        {
            return await _dbContext.Venda.FirstOrDefaultAsync(x => x.Id == id) ?? throw new Exception($"Venda {id} não encontrado no banco de dados");
        }

        public async Task<List<VendaModel>> BuscarPorIdCliente(int id)
        {
            return await _dbContext.Venda.Where(x => x.ClienteId == id).ToListAsync() ?? throw new Exception($"Vendas para o Cliente {id} não encontradas no banco de dados");
        }


        public async Task<List<VendaModel>> Insert(List<VendaModel> vendas)
        {
            await _dbContext.Venda.AddRangeAsync(vendas);
            await _dbContext.SaveChangesAsync();

            return vendas;
        }


        public async Task<VendaModel> Update(VendaModel venda, int id)
        {
            VendaModel VendaPorId = await BuscarPorId(id);

            VendaPorId.ValorVenda = venda.ValorVenda;
            VendaPorId.DtVenda = venda.DtVenda;
            VendaPorId.ClienteId = venda.ClienteId;
            VendaPorId.ProdutoId = venda.ProdutoId;
            VendaPorId.CustoProduto = venda.CustoProduto;
            VendaPorId.MetodoPagamento = venda.MetodoPagamento;
            VendaPorId.Tipo = venda.Tipo;
            VendaPorId.TipoTransacao = venda.TipoTransacao;
            VendaPorId.PreVenda = venda.PreVenda;
            VendaPorId.AlteradoPor = venda.AlteradoPor;
            VendaPorId.DtAlteracao = venda.DtAlteracao;

            _dbContext.Venda.Update(VendaPorId);
            await _dbContext.SaveChangesAsync();

            return VendaPorId;
        }

        public async Task<bool> Delete(int id)
        {
            VendaModel VendaPorId = await BuscarPorId(id);

            _dbContext.Venda.Remove(VendaPorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }

    }
}
