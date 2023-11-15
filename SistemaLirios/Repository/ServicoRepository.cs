using Microsoft.EntityFrameworkCore;
using SistemaLirios.Data;
using SistemaLirios.Models;
using SistemaLirios.Repository.Interfaces;

namespace SistemaLirios.Repository
{
    public class ServicoRepository : IServicoRepository
    {
        private readonly SistemaLiriosDBContext _dbContext;

        public ServicoRepository(SistemaLiriosDBContext sistemaLirioDBContext)
        {
            _dbContext = sistemaLirioDBContext;
        }

        public async Task<List<ServicoModel>> BuscarTodosServicos()
        {
            return await _dbContext.Servico.ToListAsync();
        }

        public async Task<List<ServicoModel>> BuscarPorTipo(int tipo)
        {
            return await _dbContext.Servico.Where(x => x.TipoServicoId == tipo).ToListAsync() ?? throw new Exception($"Servicos do tipo {tipo} não encontrado no banco de dados");
        }

        public async Task<ServicoModel> BuscarPorId(int id)
        {
            return await _dbContext.Servico.FirstOrDefaultAsync(x => x.Id == id) ?? throw new Exception($"Servico {id} não encontrado no banco de dados");
        }

        public async Task<ServicoModel> Insert(ServicoModel Servico)
        {
            await _dbContext.Servico.AddAsync(Servico);
            await _dbContext.SaveChangesAsync();

            return Servico;
        }

        public async Task<ServicoModel> Update(ServicoModel Servico, int id)
        {
            ServicoModel ServicoPorId = await BuscarPorId(id);

            ServicoPorId.TipoServicoId = Servico.TipoServicoId;
            ServicoPorId.Nome = Servico.Nome;
            ServicoPorId.Valor = Servico.Valor;
            ServicoPorId.Ativo = Servico.Ativo;
            ServicoPorId.AlteradoPor = Servico.AlteradoPor;
            ServicoPorId.DtAlteracao = Servico.DtAlteracao;

            _dbContext.Servico.Update(ServicoPorId);
            await _dbContext.SaveChangesAsync();

            return ServicoPorId;
        }

        public async Task<bool> Delete(int id)
        {
            ServicoModel ServicoPorId = await BuscarPorId(id);

            _dbContext.Servico.Remove(ServicoPorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }

    }
}
