using Microsoft.EntityFrameworkCore;
using SistemaLirios.Data;
using SistemaLirios.Models;
using SistemaLirios.Repository.Interfaces;

namespace SistemaLirios.Repository
{
    public class RelatorioRepository : IRelatorioRepository
    {
        private readonly SistemaLiriosDBContext _dbContext;

        public RelatorioRepository(SistemaLiriosDBContext sistemaLirioDBContext)
        {
            _dbContext = sistemaLirioDBContext;
        }

        public async Task<List<HistoricoModel>> RetornaHistorico(int id)
        {
            var historico = await _dbContext.Historico.FromSqlRaw(@"
                SELECT 'Venda' AS TipoEvento, p.Nome as Produto, v.Quantidade as Quantidade, v.ValorVenda AS Valor, v.CustoProduto, null as Lucro, v.DtVenda AS DataEvento
                FROM Venda as v
                INNER JOIN Produto as p ON v.ProdutoId = p.Id
                WHERE ClienteId = {0}

                UNION ALL

                SELECT 'Pagamento' AS TipoEvento, null as Produto, null as Quantidade, ValorPago AS Valor, null, null as Lucro, DtPagamento AS DataEvento
                FROM Pagamento
                WHERE ClienteId = {0}

                ORDER BY DataEvento DESC;", id)
                .ToListAsync();

            return historico;
        }
    }
}
