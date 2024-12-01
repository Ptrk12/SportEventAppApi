using ApplicationCore.Models;
using ApplicationCore.Models.req;
using Infrastructure.Entities;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;


namespace Managers.managers
{
    public class UserManager : IUserManager
    {
        private readonly IUserRepository _userRepository;
        private readonly UserManager<UserEntity> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserManager(IUserRepository userRepository, UserManager<UserEntity> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _userRepository = userRepository;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<bool> ChangePassword(ChangePasswordReq req)
        {
            var userPrincipal =  _httpContextAccessor.HttpContext.User;

            if (userPrincipal == null)
                return false;

            var user = await _userManager.GetUserAsync(userPrincipal);
            var result = await _userManager.ChangePasswordAsync(user, req.OldPassword, req.NewPassword);

            if (result.Succeeded)
                return true;
            return false;
        }

        public async Task<UserInfo> GetUserInfo()
        {
            var createdBy = _userRepository.GetUserEmailFromToken();
            UserInfo result = new UserInfo();

            if(!string.IsNullOrEmpty(createdBy))
            {
                var userMoney = await _userRepository.GetUserMone(createdBy);
                result.Money = (double)userMoney;
                result.Email = createdBy;
            }
            return result;
        }
    }

    public interface IUserManager
    {
        Task<UserInfo> GetUserInfo();
        Task<bool> ChangePassword(ChangePasswordReq req);
    }
}
