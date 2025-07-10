namespace StudentManagementSystem.Models.Academic
{
    public class Registration
    {
        public int Id { get; set; }
        public string StudentId { get; set; } = "";
        public int CourseId { get; set; }
        public bool IsApproved { get; set; }
        public bool IsPaid { get; set; }
        public decimal Fee { get; set; }

        public Student? Student { get; set; }
        public Course? Course { get; set; }

        public ICollection<RegisteredCourse> RegisteredCourses { get; set; } = new List<RegisteredCourse>();
    }
}