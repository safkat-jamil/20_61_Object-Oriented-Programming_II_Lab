namespace StudentManagementSystem.Models.Academic
{
    public enum RoutineType { Class, Test, Presentation, FinalExam }

    public class Routine
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public RoutineType Type { get; set; }
        public DateTime ScheduledAt { get; set; }

        public Course? Course { get; set; }
    }
}