namespace StudentManagementSystem.Models.Academic
{
    public class StudyMaterial
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public string FilePath { get; set; } = "";
        public DateTime UploadedAt { get; set; }

        public Course? Course { get; set; }
    }
}