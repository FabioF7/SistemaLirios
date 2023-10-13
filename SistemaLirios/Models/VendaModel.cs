using SistemaLirios.Enums;

namespace SistemaLirios.Models
{
    public class VendaModel
    {
        public int Id { get; set; }
        public float ValorVenda { get; set; }
        public DateTime DtVenda { get; set; }
        public int IdCliente { get; set; }
        public int IdProduto { get; set; }
        public float CustoProduto { get; set; }
        public MetodoPagamento MetodoPagamento { get; set; }
        public Tipo Tipo { get; set; }
        public TipoTransacao TipoTransacao { get; set; }
        public string? CadastradoPor { get; set; }
        public int PreVenda { get; set; }
        public string? AlteradoPor { get; set; }
        public DateTime DtAlteracao { get; set; }
  
    }
}
