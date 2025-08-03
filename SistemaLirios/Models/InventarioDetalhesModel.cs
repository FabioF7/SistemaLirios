namespace SistemaLirios.Models
{
    public class InventarioDetalhesModel
    {
        public int? Id { get; set; }
        public int? IdInventario { get; set; }
        public virtual InventarioModel? Inventario { get; set; }
        public int? IdProduto { get; set; }
        public virtual ProdutoModel? Produto { get; set; }
        public int? Previsao { get; set; }
        public int? Contabilizado { get; set; }
    }
}
