using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem.Models
{
    public interface ICaptchaViewModel
    {
        string CaptchaCode { get; set; }
        string CaptchaInput { get; set; }
    }
}
