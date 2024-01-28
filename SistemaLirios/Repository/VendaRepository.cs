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
        private readonly IProdutoRepository _produtoRepository;
        private readonly IPagamentoRepository _pagamentoRepository;

        public VendaRepository(SistemaLiriosDBContext sistemaLirioDBContext, IProdutoRepository produtoRepository, IPagamentoRepository pagamentoRepository)
        {
            _dbContext = sistemaLirioDBContext;
            _produtoRepository = produtoRepository;
            _pagamentoRepository = pagamentoRepository;
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

        public async Task<List<VendaModel>> Insert(List<VendaModel> vendas, string valorPago)
        {
            int ultimoIdNoBanco = await _dbContext.Venda.MaxAsync(v => (int?)v.IdVenda) ?? 0;

            int novoId = ultimoIdNoBanco + 1;

            foreach (var venda in vendas)
            {
                venda.IdVenda = novoId;
                await _dbContext.Venda.AddAsync(venda);
                await _dbContext.SaveChangesAsync();

                if (venda.PreVenda == 0)
                {
                    await AlteraEstoque(venda);
                }
            }

            if (valorPago != null)
            {
                PagamentoModel pagamento = new PagamentoModel();

                pagamento.ClienteId = vendas.FirstOrDefault().ClienteId;
                pagamento.ValorPago = float.Parse(valorPago);
                pagamento.TipoTransacao = vendas.FirstOrDefault().TipoTransacao;
                pagamento.MetodoPagamento = vendas.FirstOrDefault().MetodoPagamento;
                pagamento.DtPagamento = DateTime.Now;
                pagamento.CadastradoPor = vendas.FirstOrDefault().CadastradoPor;

                await IncluiPagamento(pagamento);
            }

            return vendas;
        }

        public async Task IncluiPagamento(PagamentoModel pagamento)
        {
            await _pagamentoRepository.Insert(pagamento);
        }

        public async Task AlteraEstoque(VendaModel vendas)
        {
            var produtoAtual = await _dbContext.Produto.FirstOrDefaultAsync(x => x.Id == vendas.ProdutoId);

            if (produtoAtual != null)
            {
                produtoAtual.Quantidade -= vendas.Quantidade;
                await _produtoRepository.Update(produtoAtual, produtoAtual.Id);
            }
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
