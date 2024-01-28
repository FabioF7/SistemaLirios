using Microsoft.EntityFrameworkCore;
using SistemaLirios.Data;
using SistemaLirios.Enums;
using SistemaLirios.Models;
using SistemaLirios.Repository.Interfaces;

namespace SistemaLirios.Repository
{
    public class PagamentoRepository : IPagamentoRepository
    {

        private readonly SistemaLiriosDBContext _dbContext;

        public PagamentoRepository(SistemaLiriosDBContext sistemaLirioDBContext)
        {
            _dbContext = sistemaLirioDBContext;
        }

        public async Task<List<PagamentoModel>> BuscarTodosPagamentos()
        {
            return await _dbContext.Pagamento.ToListAsync();
        }

        public async Task<PagamentoModel> BuscarPorId(int id)
        {
            return await _dbContext.Pagamento.FirstOrDefaultAsync(x => x.Id == id) ?? throw new Exception($"Pagamento {id} não encontrado no banco de dados");
        }

        public async Task<List<PagamentoModel>> BuscarPorIdCliente(int id)
        {
            return await _dbContext.Pagamento.Where(x => x.ClienteId == id).ToListAsync() ?? throw new Exception($"Pagamentos para o Cliente {id} não encontradas no banco de dados");
        }

        public async Task<PagamentoModel> Insert(PagamentoModel pagamento)
        {
            await _dbContext.Pagamento.AddAsync(pagamento);
            await _dbContext.SaveChangesAsync();

            return pagamento;
        }

        public async Task<PagamentoModel> Update(PagamentoModel pagamento, int id)
        {
            PagamentoModel PagamentoPorId = await BuscarPorId(id);

            PagamentoPorId.ClienteId = pagamento.ClienteId;
            PagamentoPorId.ValorPago = pagamento.ValorPago;
            PagamentoPorId.TipoTransacao = pagamento.TipoTransacao;
            PagamentoPorId.MetodoPagamento = pagamento.MetodoPagamento;

            _dbContext.Pagamento.Update(PagamentoPorId);
            await _dbContext.SaveChangesAsync();

            return PagamentoPorId;
        }

        public async Task<bool> Delete(int id)
        {
            PagamentoModel PagamentoPorId = await BuscarPorId(id);

            _dbContext.Pagamento.Remove(PagamentoPorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public float RetornaDivida(List<PagamentoModel> pagamento, List<VendaModel> venda)
        {
            float valorGasto = 0.00f;
            float valorPago = 0.00f;
            
            foreach (var vendas in venda)
            {
                if (vendas.TipoTransacao == 0)
                {
                    valorGasto += vendas.ValorVenda;
                }
            }

            foreach (var pagamentos in pagamento)
            {
                if (pagamentos.TipoTransacao == 0)
                {
                    valorPago += pagamentos.ValorPago;
                }
                else
                {
                    valorPago -= pagamentos.ValorPago;
                }
            }

            return valorGasto - valorPago;
        }
    }
}
