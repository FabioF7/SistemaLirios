using Microsoft.AspNetCore.Identity;
using SistemaLirios.Enums;

namespace SistemaLirios.Models
{
    public class LoginModel
    {
        public string? Usuario { get; set; }
        public string? Senha { get; set; }
    }
}
