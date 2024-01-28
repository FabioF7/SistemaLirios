using Microsoft.AspNetCore.Identity;
using SistemaLirios.Enums;

namespace SistemaLirios.Models
{
    public class PerfilModel
    {
        public int Id { get; set; }
        public string? NomePerfil { get; set; }
        public string? DescricaoPerfil { get; set; }
        public int Ativo { get; set; }
        public DateTime DtCadastro { get; set; }
        public DateTime? DtAlteracao { get; set; }
    }
}
