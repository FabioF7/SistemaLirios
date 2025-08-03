namespace SistemaLirios.Models
{
    public class ProdutoModel
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public int OrigemId { get; set; }
        public virtual OrigemModel? Origem { get; set; }
        public string? Codigo { get; set; }
        public Int64? CodigoDeBarra { get; set; }
        public double ValorCusto { get; set; }
        public double ValorVendaRevista { get; set; }
        public int? IdCategoria { get; set; } //Verificar se irá criar Enum
        public int Quantidade { get; set; }
        public string? CadastradoPor { get; set; }
        public DateTime? DtCadastro { get; set; }
        public string? AlteradoPor { get; set; }
        public DateTime? DtAlteracao { get; set; }
          
    }
}
