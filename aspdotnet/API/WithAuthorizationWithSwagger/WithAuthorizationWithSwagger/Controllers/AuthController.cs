using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WithAuthorizationWithSwagger.Models;

namespace WithAuthorizationWithSwagger.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            if(model == null)
                return BadRequest("Invalid Client Request");
            
            if(model.Username=="john@g.in" && model.Password == "john123")
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@2410"));
                var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
                var tokenOptions = new JwtSecurityToken(
                    issuer:"Nikunj",
                    audience: "https://localhost:7299",
                    claims:new List<Claim>(),
                    expires:DateTime.Now.AddDays(10),
                    signingCredentials:signingCredentials
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
