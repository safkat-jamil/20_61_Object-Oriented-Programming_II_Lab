using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem.Models
{
    public class StudentRegistrationViewModel : ICaptchaViewModel
    {
        [Required(ErrorMessage = "Student ID is required.")]
        [MaxLength(20)]
        public string StudentId { get; set; } = string.Empty;

        [Required(ErrorMessage = "First name is required.")]
        [MaxLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [MaxLength(50)]
        public string? MiddleName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        [MaxLength(50)]
        public string LastName { get; set; } = string.Empty;

        [MaxLength(50)]
        public string? NickName { get; set; }

        [Required(ErrorMessage = "Father's Name is required")]
        [MaxLength(100)]
        public string FatherName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Mother's Name is required")]
        [MaxLength(100)]
        public string MotherName { get; set; } = string.Empty;

        [MaxLength(100)]
        public string? GurdianName { get; set; }

        [Required(ErrorMessage = "Date of birth is required.")]
        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        public string Gender { get; set; } = string.Empty;

        [Required(ErrorMessage = "Phone number is required.")]
        [Phone, MaxLength(20)]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email address is required.")]
        [EmailAddress, MaxLength(255)]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please confirm your password.")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        public string ConfirmPassword { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please upload your photo.")]
        public IFormFile Photo { get; set; } = default!;

        [Required(ErrorMessage = "CAPTCHA generation failed.")]
        public string CaptchaCode { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter the CAPTCHA.")]
        public string CaptchaInput { get; set; } = string.Empty;
    }
}
