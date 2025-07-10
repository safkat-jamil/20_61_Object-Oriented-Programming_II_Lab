namespace StudentManagementSystem.Models.Academic
{
    public class Notification
    {
        public int Id { get; set; }
        public string UserRole { get; set; } = ""; // Student, Faculty, Admin
        public string UserId { get; set; } = "";   // StudentId or FacultyId
        public string Message { get; set; } = "";
        public DateTime CreatedAt { get; set; }
        public bool IsRead { get; set; }
    }
}