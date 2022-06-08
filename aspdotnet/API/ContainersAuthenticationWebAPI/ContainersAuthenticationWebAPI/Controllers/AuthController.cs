using ContainersAuthenticationWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ContainersAuthenticationWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost]
        public IActionResult Login(Login _login)
        {
            if(_login == null)
                return BadRequest("Invalid Client Request");
            
            if (_login.UserName == "john" && _login.Password == "john123")
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@2410"));
                var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
                var tokenOptions = new JwtSecurityToken(
                    issuer: "Nikunj",
                    audience: "https://localhost:7299",
                    claims: new List<Claim>(),
                    expires: DateTime.Now.AddDays(10),
                    signingCredentials: signingCredentials
                    );
                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                return Ok(new { tokenString });
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
