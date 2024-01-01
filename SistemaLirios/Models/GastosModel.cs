namespace SistemaLirios.Models
{
    public class GastosModel
    {

        public int? Id { get; set; }
        public string? NomeGasto { get; set; }
        public float Valor { get; set; }
        public int Recorrente { get; set; }
        public int TipoServicoId { get; set; }
        public virtual TipoServicoModel? TipoServico { get; set; }
        public DateTime? DtCadastro { get; set; }
        public string? CadastradoPor { get; set; }
        public DateTime? DtAlteracao { get; set; }
        public string? AlteradoPor { get; set; }

    }
}
