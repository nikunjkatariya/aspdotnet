using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIJWT.Model;
using WebAPIJWT.Repository;

namespace WebAPIJWT.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IJWTManagerRepository _JWTManager;

        public UsersController(IJWTManagerRepository JWTManager)
        {
            this._JWTManager = JWTManager;
        }
        [HttpGet]
        public List<string> Get()
        {
            var users = new List<string>
            {
                "DataOne",
                "DataTwo"
            };
            return users;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("authenticate")]
        public IActionResult Authenticate(Users userdata)
        {
            var token = _JWTManager.Authenticate(userdata);
            if(token == null)
            {
                return Unauthorized();
            }
            return Ok(token);
        }
    }
}
