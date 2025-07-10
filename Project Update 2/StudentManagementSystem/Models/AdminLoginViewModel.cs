using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem.Models
{
    public class AdminLoginViewModel : ICaptchaViewModel
    {
        [Required(ErrorMessage = "Username is required.")]
        public string Username { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        [Required]
        public string CaptchaCode { get; set; } = string.Empty;

        [Required]
        public string CaptchaInput { get; set; } = string.Empty;
    }
}
