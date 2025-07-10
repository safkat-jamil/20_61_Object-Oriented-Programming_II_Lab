using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem.Models
{
    public class Faculty
    {
        [Key]
        [MaxLength(50)]
        public string FacultyId { get; set; } = string.Empty;

        [Required(ErrorMessage = "Name is required.")]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        [MaxLength(255)]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password hash is required.")]
        public string PasswordHash { get; set; } = string.Empty;
    }
}
