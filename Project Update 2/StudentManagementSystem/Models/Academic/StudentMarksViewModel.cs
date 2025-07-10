namespace StudentManagementSystem.Models.Academic
{
    public class StudentMarksViewModel
    {
        public string Course { get; set; } = string.Empty;
        public int ClassTestMark { get; set; }
        public int PresentationMark { get; set; }
        public int AttendanceMark { get; set; }
        public int FinalExamMark { get; set; }
    }
}
