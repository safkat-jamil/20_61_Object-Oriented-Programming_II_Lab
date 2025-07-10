namespace StudentManagementSystem.Models.Academic
{
    public class Course
    {
        public int Id { get; set; }
        public string Code { get; set; } = "";
        public string Title { get; set; } = "";
        public int Semester { get; set; }
        public int ExamYear { get; set; }
        public CourseType Type { get; set; }
    }
}
