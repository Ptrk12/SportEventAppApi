using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Entities
{
    public class UserEntity : IdentityUser
    {
        public double Money { get; set; }
        public UserEntity()
        {
            Money = 100;
        }
    }
   
}
