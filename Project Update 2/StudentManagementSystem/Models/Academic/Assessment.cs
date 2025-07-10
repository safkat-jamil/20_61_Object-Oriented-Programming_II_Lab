namespace StudentManagementSystem.Models.Academic
{
    public class Assessment
    {
        public int Id { get; set; }
        public int RegistrationId { get; set; }
        public int ClassTestMark { get; set; }
        public int PresentationMark { get; set; }
        public int AttendanceMark { get; set; }

        public Registration? Registration { get; set; }
    }
}