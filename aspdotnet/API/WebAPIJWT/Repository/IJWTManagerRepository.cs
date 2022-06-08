using WebAPIJWT.Model;

namespace WebAPIJWT.Repository
{
    public interface IJWTManagerRepository
    {
        Tokens Authenticate(Users users);
    }
}
