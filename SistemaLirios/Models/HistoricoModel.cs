namespace SistemaLirios.Models
{
    public class HistoricoModel
    {
        public string? TipoEvento { get; set; }
        public string? Produto { get; set; }
        public int? Quantidade { get; set; }
        public double? CustoProduto { get; set; }
        public double? Valor { get; set; }
        public double? Lucro { get; set; }
        public DateTime? DataEvento { get; set; }
    }
}
