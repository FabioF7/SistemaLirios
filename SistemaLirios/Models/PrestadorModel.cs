using SistemaLirios.Enums;

namespace SistemaLirios.Models
{
    public class PrestadorModel
    {

        public int Id { get; set; }
        public string? Nome { get; set; }
        public int TipoServicoId { get; set; }
        public virtual TipoServicoModel? TipoServico { get; set; }
        public string? Local { get; set; }
        public int Ativo { get; set; }
        public DateTime DtCadastro { get; set; }
        public string? CadastradoPor { get; set; }
        public DateTime DtAlteracao { get; set; }
        public string? AlteradoPor { get; set; }
    }
}
