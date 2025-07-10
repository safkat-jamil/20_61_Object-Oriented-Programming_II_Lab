namespace StudentManagementSystem.Models.Academic
{
    public class FeeSetting
    {
        public int Id { get; set; }
        public int Semester { get; set; }
        public int ExamYear { get; set; }
        public decimal RegistrationFee { get; set; }
        public decimal ImprovementFee { get; set; }
    }
}
