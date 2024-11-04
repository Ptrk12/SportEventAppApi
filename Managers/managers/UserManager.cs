using ApplicationCore.Models;
using Infrastructure.Repositories;

namespace Managers.managers
{
    public class UserManager : IUserManager
    {
        private readonly IUserRepository _userRepository;

        public UserManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;
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
    }
}
