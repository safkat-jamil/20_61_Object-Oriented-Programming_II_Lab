using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem.Models
{
    public class FacultyLoginViewModel : ICaptchaViewModel
    {
        [Required(ErrorMessage = "Faculty ID or Email is required.")]
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