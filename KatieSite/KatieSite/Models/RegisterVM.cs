using System.ComponentModel.DataAnnotations;

namespace KatieSite.Models
{
    public class RegisterVM
    {
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
