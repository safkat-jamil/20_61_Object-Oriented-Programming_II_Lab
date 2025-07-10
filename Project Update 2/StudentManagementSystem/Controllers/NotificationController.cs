using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.Data;
using StudentManagementSystem.Models.Academic;
using System.Linq;

namespace StudentManagementSystem.Controllers
{
    public class NotificationController : Controller
    {
        private readonly AppDbContext _db;
        public NotificationController(AppDbContext db) => _db = db;

        public IActionResult Index()
        {
            var role = HttpContext.Session.GetString("UserRole");
            var idKey = role == "Student" ? "StudentId" : "FacultyId";
            var id = HttpContext.Session.GetString(idKey);
            if (role == null || id == null) return RedirectToAction("Index", "Home");

            var notes = _db.Notifications
                           .Where(n => n.UserRole == role && n.UserId == id)
                           .OrderByDescending(n => n.CreatedAt)
                           .ToList();
            return View(notes);
        }

        [HttpPost]
        public IActionResult MarkRead(int id)
        {
            var note = _db.Notifications.Find(id);
            if (note != null) { note.IsRead = true; _db.SaveChanges(); }
            return RedirectToAction(nameof(Index));
        }
    }
}
