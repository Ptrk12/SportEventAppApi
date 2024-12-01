
using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Models.req
{
    public class ChangePasswordReq
    {
        [Required]
        public string OldPassword { get; set; }
        [Required]
        public string NewPassword { get; set; }
    }
}
