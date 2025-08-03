using SistemaLirios.Models;

namespace SistemaLirios.Repository.Interfaces
{
    public interface IRelatorioRepository
    {

        Task<List<HistoricoModel>> RetornaHistorico(int id);

    }
}
