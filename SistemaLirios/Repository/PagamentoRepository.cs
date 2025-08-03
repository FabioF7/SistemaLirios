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
        private readonly IClienteRepository _clienteRepository;


        public PagamentoRepository(SistemaLiriosDBContext sistemaLirioDBContext, IClienteRepository clienteRepository)
        {
            _dbContext = sistemaLirioDBContext;
            _clienteRepository = clienteRepository;
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

        public async Task<double> RetornaDivida(List<PagamentoModel> pagamento, List<VendaModel> venda)
        {
            if (pagamento.Count > 0 && venda.Count > 0)
            {
                double valorGasto = 0.00f;
                double valorPago = 0.00f;

                foreach (var vendas in venda)
                {
                    if (vendas.TipoTransacao == 0)
                    {
                        valorGasto += vendas.ValorVenda * vendas.Quantidade;
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

                double result = 0.00f;
                result = valorGasto - valorPago;
                string formatado = result.ToString("F2");
                result = double.Parse(formatado);

                AtualizaInadimplencia(result, venda.FirstOrDefault().ClienteId);

                return await Task.FromResult(result);
            }

            return await Task.FromResult(0);
        }

        public async void AtualizaInadimplencia(double result, int id)
        {
            if (result > 0)
            {
                ClienteModel cliente = new ClienteModel();

                cliente.Inadimplencia = 1;

                await _clienteRepository.Update(cliente, id);
            }
            else if (result == 0)
            {
                ClienteModel cliente = new ClienteModel();

                cliente.Inadimplencia = 0;

                await _clienteRepository.Update(cliente, id);
            }
        }


    }
}
