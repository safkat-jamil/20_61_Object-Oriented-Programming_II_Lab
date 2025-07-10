using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem.Models
{
    public class StudentLoginViewModel : ICaptchaViewModel
    {
        [Required(ErrorMessage = "Student ID or Email is required.")]
        [StringLength(100, MinimumLength = 5)]
        public string Identifier { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        [Required]
        public string CaptchaCode { get; set; } = string.Empty;

        [Required]
        public string CaptchaInput { get; set; } = string.Empty;
    }
}
