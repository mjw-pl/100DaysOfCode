using Day002.Models;

namespace Day002.Authentication
{
    public interface IAuthenticationService
    {
        Task<bool> Login(DtoUserLoginRequest request);
        Task<bool> Logout();
    }
}