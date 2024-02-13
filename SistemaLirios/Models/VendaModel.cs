using SistemaLirios.Enums;

namespace SistemaLirios.Models
{
    public class VendaModel
    {
        public int Id { get; set; }
        public int IdVenda { get; set; }
        public double ValorVenda { get; set; }
        public DateTime DtVenda { get; set; }
        public int ClienteId { get; set; }
        public virtual ClienteModel? Cliente { get; set; }
        public int ProdutoId { get; set; }
        public virtual ProdutoModel? Produto { get; set; }
        public double CustoProduto { get; set; }
        public MetodoPagamento MetodoPagamento { get; set; }
        public Tipo Tipo { get; set; }
        public TipoTransacao TipoTransacao { get; set; }
        public int Quantidade { get; set; }
        public int? PreVenda { get; set; }
        public string? CadastradoPor { get; set; }
        public string? AlteradoPor { get; set; }
        public DateTime? DtAlteracao { get; set; }
    }
}

