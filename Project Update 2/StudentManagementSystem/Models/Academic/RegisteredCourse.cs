using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManagementSystem.Models.Academic
{
    public class RegisteredCourse
    {
        public int Id { get; set; }

        public int CourseId { get; set; }
        public Course? Course { get; set; }

        public int RegistrationId { get; set; }
        public Registration? Registration { get; set; }
    }
}