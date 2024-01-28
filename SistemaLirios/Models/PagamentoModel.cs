using SistemaLirios.Enums;

namespace SistemaLirios.Models
{
    public class PagamentoModel
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public virtual ClienteModel? Cliente { get; set; }
        public float ValorPago { get; set; }
        public TipoTransacao TipoTransacao { get; set; }
        public MetodoPagamento MetodoPagamento { get; set; }
        public DateTime DtPagamento { get; set; }
        public string? CadastradoPor { get; set; }
    }
}
