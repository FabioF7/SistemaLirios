using Microsoft.EntityFrameworkCore;
using SistemaLirios.Data;
using SistemaLirios.Models;
using SistemaLirios.Repository.Interfaces;

namespace SistemaLirios.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly SistemaLiriosDBContext _dbContext;

        public ProdutoRepository(SistemaLiriosDBContext sistemaLirioDBContext)
        {
            _dbContext = sistemaLirioDBContext;
        }

        public async Task<List<ProdutoModel>> BuscarTodosProdutos()
        {
            return await _dbContext.Produto.ToListAsync();
        }
        public async Task<List<ProdutoModel>> BuscarPorCategoria(int categoria)
        {
            var sql = string.Format("select * from Produto where IdCategoria = {0}", categoria) ?? throw new Exception($"Produtos da categoria {categoria} não encontrados no banco de dados");

            return await _dbContext.Produto.FromSqlRaw(sql).ToListAsync();
        }

        public async Task<List<ProdutoModel>> BuscarPorOrigem(int origem)
        {
            var sql = string.Format("select * from Produto where OrigemId = {0}", origem) ?? throw new Exception($"Produtos da origem {origem} não encontrados no banco de dados");

            return await _dbContext.Produto.FromSqlRaw(sql).ToListAsync();
        }

        public async Task<List<ProdutoModel>> BuscarPorData(DateTime dataInicio, DateTime dataFim)
        {
            return await _dbContext.Produto.Where(x => x.DtCadastro >= dataInicio && x.DtCadastro <= dataFim).ToListAsync();
        }

        public async Task<ProdutoModel> BuscarPorId(int id)
        {
            return await _dbContext.Produto.FirstOrDefaultAsync(x => x.Id == id) ?? throw new Exception($"Produto {id} não encontrado no banco de dados");
        }

        public async Task<ProdutoModel> Insert(ProdutoModel produto)
        {
            await _dbContext.Produto.AddAsync(produto);
            await _dbContext.SaveChangesAsync();

            return produto;
        }

        public async Task<ProdutoModel> Update(ProdutoModel produto, int id)
        {
            ProdutoModel produtoPorId = await BuscarPorId(id);

            produtoPorId.Nome = produto.Nome;
            produtoPorId.OrigemId = produto.OrigemId;
            produtoPorId.Codigo = produto.Codigo;
            produtoPorId.CodigoDeBarra = produto.CodigoDeBarra;
            produtoPorId.ValorCusto = produto.ValorCusto;
            produtoPorId.ValorVendaRevista = produto.ValorVendaRevista;
            produtoPorId.IdCategoria = produto.IdCategoria;
            produtoPorId.DtAlteracao = produto.DtAlteracao;
            produtoPorId.Quantidade = produto.Quantidade;
            produtoPorId.Ativo = produto.Ativo;
            produtoPorId.AlteradoPor = produto.AlteradoPor;

            _dbContext.Produto.Update(produtoPorId);
            await _dbContext.SaveChangesAsync();

            return produtoPorId;

    }
        public async Task<bool> Delete(int id)
        {
            ProdutoModel produtoPorId = await BuscarPorId(id);

            _dbContext.Produto.Remove(produtoPorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }

    }
}
