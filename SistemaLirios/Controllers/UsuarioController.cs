using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SistemaLirios.Models;
using SistemaLirios.Repository;
using SistemaLirios.Repository.Interfaces;
using SistemaLirios.Requests;
using System.IdentityModel.Tokens.Jwt;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace SistemaLirios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public UsuarioController(IUsuarioRepository usuarioRepository) 
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpPost]
        [Authorize (Roles = "Admin")]
        public async Task<ActionResult<UsuarioModel>> Insert([FromBody] UsuarioRequest usuarioRequest)
        {
            try
            {
                CriaPasswordHash(usuarioRequest.Senha, out byte[] passwordHash, out byte[] passwordSalt);

                UsuarioModel usuarioModel = new UsuarioModel();

                usuarioModel.Nome = usuarioRequest.Nome;
                usuarioModel.Usuario = usuarioRequest.Usuario;
                usuarioModel.PasswordHash = passwordHash;
                usuarioModel.PasswordSalt = passwordSalt;
                usuarioModel.DtCadastro = DateTime.Now;
                usuarioModel.Ativo = 1;
                usuarioModel.IdPerfil = usuarioRequest.IdPerfil;

                UsuarioModel usuario = await _usuarioRepository.Insert(usuarioModel);

                if (usuario == null)
                {
                    return BadRequest("Não foi possível incluir Usuario!");
                }

                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um Erro: {ex}");
            }
        }

        [HttpPut("{id}")]
        [Authorize (Roles = "Admin")]
        public async Task<ActionResult<UsuarioModel>> Update(int id, [FromBody] UsuarioRequest usuarioRequest)
        {
            try
            {
                UsuarioModel usuarioModel = new UsuarioModel();

                if (usuarioRequest.Senha != null) {
                    CriaPasswordHash(usuarioRequest.Senha, out byte[] passwordHash, out byte[] passwordSalt);

                    usuarioModel.PasswordHash = passwordHash;
                    usuarioModel.PasswordSalt = passwordSalt;
                }

                usuarioModel.Nome = usuarioRequest.Nome;
                usuarioModel.Usuario = usuarioRequest.Usuario;      
                usuarioModel.DtAlteracao = DateTime.Now;
                usuarioModel.Ativo = usuarioRequest.Ativo;
                usuarioModel.IdPerfil = usuarioRequest.IdPerfil;

                UsuarioModel usuario = await _usuarioRepository.Update(usuarioModel, id);

                if (usuario == null)
                {
                    return BadRequest("Não foi possível alterar Usuario!");
                }

                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um Erro: {ex}");
            }
        }

        [HttpDelete("{id}")]
        [Authorize (Roles = "Admin")]
        public async Task<ActionResult<UsuarioModel>> Delete(int id)
        {
            try
            {
                bool sucesso = await _usuarioRepository.Delete(id);

                if (!sucesso)
                {
                    return BadRequest("Não foi possível excluir Usuario!");
                }

                return Ok(sucesso);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um Erro: {ex}");
            }
        }

        [HttpPost("Login")]
        public async Task<ActionResult<UsuarioModel>> Login(LoginModel loginModel)
        {
            try
            {
                UsuarioModel usuario = new UsuarioModel();

                if (loginModel.Usuario != null)
                {
                    usuario = await _usuarioRepository.BuscarPorUsuario(loginModel.Usuario);
                }
                else
                {
                    return BadRequest("Usuario incorreto!");
                }
            
                if (!VerificaPasswordHash(loginModel.Senha, usuario.PasswordHash, usuario.PasswordSalt))
                {
                    return BadRequest("Senha incorreta!");
                }

                string token = CriaToken(usuario);
                return Ok(token);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um Erro: {ex}");
            }
        }

        private void CriaPasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
                using (var hmac = new HMACSHA512())
                {
                    passwordSalt = hmac.Key;
                    passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                }
        }

        private bool VerificaPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }

        private string CriaToken(UsuarioModel usuario)
        {
            try
            {
                List<Claim> claims = new List<Claim>
                    {
                    new Claim(ClaimTypes.Name, usuario.Usuario),
                    new Claim(ClaimTypes.Role, usuario.Perfil.NomePerfil)
                    };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("CHAVE_SECRETA_JWT")));

                var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

                var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: cred
                    );

                var jwt = new JwtSecurityTokenHandler().WriteToken(token);

                return jwt;
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
