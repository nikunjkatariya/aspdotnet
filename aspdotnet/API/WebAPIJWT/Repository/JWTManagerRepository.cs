using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebAPIJWT.Model;


namespace WebAPIJWT.Repository
{
    public class JWTManagerRepository: IJWTManagerRepository
    {
        Dictionary<string, string> UserRecords = new Dictionary<string, string>()
        {
            {"string","string"},
            {"user1","user1"}
        };

        private readonly IConfiguration iconfiguration;
        public JWTManagerRepository(IConfiguration iconfiguration)
        {
            this.iconfiguration = iconfiguration;
        }
        public Tokens Authenticate(Users users)
        {
            if (!UserRecords.Any(x => x.Key == users.UserName && x.Value == users.Password))
            {
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(iconfiguration["JWT:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, users.UserName)
                }),
                Expires = DateTime.UtcNow.AddMinutes(10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey),SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new Tokens { Token = tokenHandler.WriteToken(token) };

        }
    }
}
