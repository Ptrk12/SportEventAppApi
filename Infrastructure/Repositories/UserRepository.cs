using Microsoft.AspNetCore.Http;
using SportEventAppApi.Config;
using System.Security.Claims;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly SportEventAppDbContext _context;

        public UserRepository(IHttpContextAccessor httpContextAccessor, SportEventAppDbContext context)
        {
            _httpContextAccessor = httpContextAccessor;
            _context = context;
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
        public async Task<bool> UpdateUserMoney(string email,double money)
        {
            try
            {
                var user = _context.Users.FirstOrDefault(x => x.Email == email);
                if(user != null)
                {
                    user.Money = money;
                    _context.ChangeTracker.Clear();
                    _context.Entry(user).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
        public async Task<double?> GetUserMone(string email)
        {
            try
            {
                var user =  _context.Users.FirstOrDefault(x => x.Email == email);
                if (user != null)
                {
                    return user.Money;
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
    public interface IUserRepository
    {
        string? GetUserEmailFromToken();
        bool CheckIfAdmin();
        Task<bool> UpdateUserMoney(string email, double money);
        Task<double?> GetUserMone(string email);
    }
}
