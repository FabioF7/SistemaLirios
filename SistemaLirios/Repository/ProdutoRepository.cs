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
            //return await _dbContext.Produto.FirstOrDefaultAsync(x => x.IdCategoria == categoria);
            throw new NotImplementedException();
        }

        public async Task<List<ProdutoModel>> BuscarPorOrigem(int origem)
        {
            //return await _dbContext.Produto.FirstOrDefaultAsync(x => x.CodigoOrigem == origem);
            throw new NotImplementedException();
        }

        public async Task<List<ProdutoModel>> BuscarPorData(DateTime dataInicio, DateTime dataFim)
        {
            throw new NotImplementedException();
        }

        public async Task<ProdutoModel> BuscarPorId(int id)
        {
            return await _dbContext.Produto.FirstOrDefaultAsync(x => x.Id == id);
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

            if (produtoPorId == null)
            {
                throw new Exception($"Produto {id} não encontrado no banco de dados");
            }

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

            if (produtoPorId == null)
            {
                throw new Exception($"Produto {id} não encontrado no banco de dados");
            }

            _dbContext.Produto.Remove(produtoPorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }

    }
}
