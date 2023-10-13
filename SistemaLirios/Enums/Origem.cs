using System.ComponentModel;

namespace SistemaLirios.Enums
{
    public enum Origem
    {
        [Description("O Boticário")]
        Oboticario = 1,
        [Description("Eudora")]
        Eudora = 2,
        [Description("Natura")]
        Natura = 3,
        [Description("Avon")]
        Avon = 4,
        [Description("Tupperware")]
        Tupperware = 5,
        [Description("Lingerie")]
        Lingerie = 6,
        [Description("Doces")]
        Doces = 7,
        [Description("Produtos diversos sem origem específica")]
        Outros = 8
    }
}
