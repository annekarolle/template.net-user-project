using StoreFIAP.Entity;

namespace StoreFIAP.Services
{
    public interface ITokenService
    {
        string GetToken(User user);
    }
}
