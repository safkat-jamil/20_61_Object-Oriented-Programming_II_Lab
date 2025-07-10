namespace StudentManagementSystem.Models.Academic
{
    public class ExamReview
    {
        public int Id { get; set; }
        public int RegistrationId { get; set; }
        public string ExaminerId { get; set; } = "";           // FacultyId
        public int Mark { get; set; }
        public int ReviewOrder { get; set; }                   // 1st, 2nd, or 3rd
        public DateTime ReviewedAt { get; set; }

        public Registration? Registration { get; set; }
    }
}