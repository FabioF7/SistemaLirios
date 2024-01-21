using SistemaLirios.Models;

namespace SistemaLirios.Requests
{
    public class UsuarioRequest
    {
        public string? Nome { get; set; }
        public string? Usuario { get; set; }
        public string? Senha { get; set; }
        public int IdPerfil { get; set; } = 0;
        public int Ativo { get; set; } = 3;

    }
}
