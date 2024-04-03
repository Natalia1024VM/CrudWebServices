using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.IdentityModel.Tokens;
using PruebaTecnica.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Permissions;
using System.Text;

namespace PruebaTecnica.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AutenticacionController : ControllerBase
    {
        private readonly string secret;
        
        //metodo de autenticacion
        
        public AutenticacionController(IConfiguration configuration)
        {
            secret = configuration.GetSection("settings").GetSection("SECRET_KEY").ToString();
        }



        [HttpPost]
        [Route("Validar")]
        public IActionResult Validar([FromBody] Login request)
        {
            if (request.Password == "Admin123" && request.Email == "nattisvm@gmail.com")
            {
                var keySecret = Encoding.ASCII.GetBytes(secret);
                var claims = new ClaimsIdentity();

                claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, request.Email));

                var tokendescript = new SecurityTokenDescriptor
                {
                    Subject = claims,
                    Expires = DateTime.UtcNow.AddMinutes(5),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keySecret), SecurityAlgorithms.HmacSha256Signature)
                };

                var tokenhandler = new JwtSecurityTokenHandler();
                var tokenConfign = tokenhandler.CreateToken(tokendescript);

                string tokencreado = tokenhandler.WriteToken(tokenConfign);

                return StatusCode(StatusCodes.Status200OK, new { token = tokencreado});
            }
            else
            {

                return StatusCode(StatusCodes.Status401Unauthorized, new
                {
                    token = ""
                });
            }

        }

    }

}
