using System;
using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem.Models.Academic
{
    public class Student
    {
        [Key]
        [MaxLength(20)]
        public string StudentId { get; set; } = string.Empty;

        [Required, MaxLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [MaxLength(50)]
        public string? MiddleName { get; set; }

        [Required, MaxLength(50)]
        public string LastName { get; set; } = string.Empty;

        [MaxLength(50)]
        public string? NickName { get; set; }

        [Required, MaxLength(100)]
        public string FatherName { get; set; } = string.Empty;

        [Required, MaxLength(100)]
        public string MotherName { get; set; } = string.Empty;

        [MaxLength(100)]
        public string? GurdianName { get; set; }

        [Required, DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public string Gender { get; set; } = string.Empty;

        [Required, Phone, MaxLength(14)]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required, EmailAddress, MaxLength(255)]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string PasswordHash { get; set; } = string.Empty;

        [Required]
        public string PhotoFileName { get; set; } = string.Empty;

        [MaxLength(100)]
        public string? ResetToken { get; set; }

        public DateTime? ResetTokenExpiry { get; set; }

        [Required]
        public bool IsApproved { get; set; } = false;

        [Required]
        public bool IsDenied { get; set; } = false;
    }
}
