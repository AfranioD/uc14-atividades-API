using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Uc14ER1.Interfaces;
using Uc14ER1.Models;
using Uc14ER1.ViewModels;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace Uc14ER1.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUsuarioRepository _iUsuarioRepository;
       

        public LoginController(IUsuarioRepository iUsuarioRepository)
        {
            _iUsuarioRepository = iUsuarioRepository;
        }

        
        [HttpPost]
        public IActionResult Login(LoginViewModel dadosLogin)
        {
            try
            {
                Usuario usuarioBuscado = _iUsuarioRepository.Login(dadosLogin.email, dadosLogin.senha);

                if (usuarioBuscado == null) 
                {
                    return Unauthorized(new {msg = "E-mail e/ou Senha incorretos"});
                }

                var minhasClaims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.Id.ToString()),
                    new Claim(ClaimTypes.Role, usuarioBuscado.Tipo)
                };

                var chave = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("Uc14ER1-chave-autenticacao"));

                var credenciais = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

                var newToken = new JwtSecurityToken(
                    issuer: "Uc14ER1.webapi",
                    audience: "Uc14ER1.webapi",
                    claims: minhasClaims,
                    expires: DateTime.Now.AddMinutes(60),
                    signingCredentials: credenciais
                    );

                return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(newToken)});
            }

            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }
    }
}
