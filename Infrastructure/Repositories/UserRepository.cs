using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserRepository(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public bool CheckIfAdmin()
        {
            var result = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Role);
            return result == "administrator" ? true : false;
        }

        public string? GetUserEmailFromToken()
        {
            var result = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Email);
            return result;
        }
    }
    public interface IUserRepository
    {
        string? GetUserEmailFromToken();
        bool CheckIfAdmin();
    }
}
