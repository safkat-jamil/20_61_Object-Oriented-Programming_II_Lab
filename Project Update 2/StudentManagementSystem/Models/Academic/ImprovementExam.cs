namespace StudentManagementSystem.Models.Academic
{
    public class ImprovementExam
    {
        public int Id { get; set; }
        public int RegistrationId { get; set; }
        public bool IsApproved { get; set; }
        public bool IsPaid { get; set; }
        public decimal Fee { get; set; }

        public Registration? Registration { get; set; }
    }
}