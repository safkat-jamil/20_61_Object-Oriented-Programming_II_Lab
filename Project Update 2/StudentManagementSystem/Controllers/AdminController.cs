using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.Data;
using StudentManagementSystem.Models.Academic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagementSystem.Controllers
{
    public class AdminController : Controller
    {
        private readonly AppDbContext _db;
        public AdminController(AppDbContext db) => _db = db;

        public IActionResult Dashboard() => View();
        public IActionResult PendingStudents() => View();
        public IActionResult ManageFaculty() => View();
        public IActionResult ClassRoutine() => View();
        public IActionResult FinalExamRoutine() => View();
        public IActionResult ApproveStudentRegistrations() => View();
        public IActionResult ApproveImprovementExams() => View();
        public IActionResult ManageExamCommittee() => View();
        public IActionResult UpdateStudentFacultyInfo() => View();

        public IActionResult FeeSettings() => View(_db.FeeSettings.ToList());

        public IActionResult CreateFee() => View();

        [HttpPost]
        public async Task<IActionResult> CreateFee(FeeSetting m)
        {
            if (!ModelState.IsValid) return View(m);
            _db.FeeSettings.Add(m);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(FeeSettings));
        }

        public IActionResult EditFee(int id) => View(_db.FeeSettings.Find(id));

        [HttpPost]
        public async Task<IActionResult> EditFee(FeeSetting m)
        {
            if (!ModelState.IsValid) return View(m);
            _db.FeeSettings.Update(m);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(FeeSettings));
        }

        [HttpPost]
        public async Task<IActionResult> DeleteFee(int id)
        {
            var fee = _db.FeeSettings.Find(id);
            if (fee != null)
            {
                _db.FeeSettings.Remove(fee);
                await _db.SaveChangesAsync();
            }
            return RedirectToAction(nameof(FeeSettings));
        }

        public IActionResult ManageCourses() => View(_db.Courses.ToList());

        public IActionResult CreateCourse() => View();

        [HttpPost]
        public async Task<IActionResult> CreateCourse(Course m)
        {
            if (!ModelState.IsValid) return View(m);
            _db.Courses.Add(m);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(ManageCourses));
        }

        public IActionResult EditCourse(int id) => View(_db.Courses.Find(id));

        [HttpPost]
        public async Task<IActionResult> EditCourse(Course m)
        {
            if (!ModelState.IsValid) return View(m);
            _db.Courses.Update(m);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(ManageCourses));
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var course = _db.Courses.Find(id);
            if (course != null)
            {
                _db.Courses.Remove(course);
                await _db.SaveChangesAsync();
            }
            return RedirectToAction(nameof(ManageCourses));
        }
    }
}
