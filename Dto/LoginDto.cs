using System.ComponentModel.DataAnnotations;

namespace HMSApi.Dto
{
    public class LoginDto
    {
        [Required]
        public string email { get; set; }
        [Required]
        public string password { get; set; }
    }
}
