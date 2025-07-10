namespace StudentManagementSystem.Models.Academic
{
    public class ExamCommittee
    {
        public int Id { get; set; }
        public int Semester { get; set; }
        public int ExamYear { get; set; }
        public string ChairmanId { get; set; } = "";           // FacultyId
        public ICollection<string> MemberIds { get; set; } = new List<string>();
    }
}