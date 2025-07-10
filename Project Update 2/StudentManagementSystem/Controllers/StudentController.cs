using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Data;
using StudentManagementSystem.Models.Academic;

namespace StudentManagementSystem.Controllers
{
    public class StudentController : Controller
    {
        private readonly AppDbContext _db;
        public StudentController(AppDbContext db) => _db = db;

        private string? GetStudentId()
        {
            var sid = HttpContext.Session.GetString("StudentId");
            return string.IsNullOrEmpty(sid) ? null : sid;
        }

        public IActionResult Dashboard() => View();

        public IActionResult ApplyCourse() => RedirectToAction(nameof(CourseRegistration));
        public IActionResult ViewRoutine() => RedirectToAction(nameof(Routines));
        public IActionResult StudyMaterial() => RedirectToAction(nameof(StudyMaterials));
        public IActionResult ViewMarks() => RedirectToAction(nameof(ViewMarksAsync));

        // --- Routines ---
        public async Task<IActionResult> Routines()
        {
            var sid = GetStudentId();
            if (sid == null) return RedirectToAction("StudentLogin", "Home");

            var courseIds = await _db.Registrations
                                     .Where(r => r.StudentId == sid && r.IsApproved)
                                     .Select(r => r.CourseId)
                                     .ToListAsync();

            var routines = await _db.Routines
                                    .Include(r => r.Course)
                                    .Where(r => courseIds.Contains(r.CourseId))
                                    .OrderBy(r => r.Type)
                                    .ToListAsync();

            return View(routines);
        }

        // --- Study Materials ---
        public async Task<IActionResult> StudyMaterials()
        {
            var sid = GetStudentId();
            if (sid == null) return RedirectToAction("StudentLogin", "Home");

            var courseIds = await _db.Registrations
                                     .Where(r => r.StudentId == sid && r.IsApproved)
                                     .Select(r => r.CourseId)
                                     .ToListAsync();

            var materials = await _db.StudyMaterials
                                     .Include(m => m.Course)
                                     .Where(m => courseIds.Contains(m.CourseId))
                                     .ToListAsync();

            return View(materials);
        }

        // --- Marks ---
        public IActionResult Marks() => View();

        public async Task<IActionResult> ViewMarksAsync()
        {
            var sid = GetStudentId();
            if (sid == null) return RedirectToAction("StudentLogin", "Home");

            var regs = await _db.Registrations
                                .Where(r => r.StudentId == sid && r.IsApproved)
                                .Include(r => r.Course)
                                .ToListAsync();

            var marksList = new List<StudentMarksViewModel>();

            foreach (var r in regs)
            {
                var assess = await _db.Assessments
                                      .FirstOrDefaultAsync(a => a.RegistrationId == r.Id);

                var finalMark = await _db.ExamReviews
                                         .Where(x => x.RegistrationId == r.Id)
                                         .MaxAsync(x => (int?)x.Mark) ?? 0;

                int maxAttend, maxPres, maxTest, maxFinal;
                switch (r.Course!.Type)
                {
                    case CourseType.Laboratory:
                        maxAttend = 10; maxPres = 10; maxTest = 10; maxFinal = 60;
                        break;
                    case CourseType.ProjectWork:
                        maxAttend = 30; maxPres = 40; maxTest = 30; maxFinal = 0;
                        break;
                    case CourseType.Theory:
                    default:
                        maxAttend = 5; maxPres = 10; maxTest = 15; maxFinal = 70;
                        break;
                }

                var ctMark = Math.Min(assess?.ClassTestMark ?? 0, maxTest);
                var prMark = Math.Min(assess?.PresentationMark ?? 0, maxPres);
                var atMark = Math.Min(assess?.AttendanceMark ?? 0, maxAttend);
                var fnMark = Math.Min(finalMark, maxFinal);

                marksList.Add(new StudentMarksViewModel
                {
                    Course = r.Course.Title,
                    ClassTestMark = ctMark,
                    PresentationMark = prMark,
                    AttendanceMark = atMark,
                    FinalExamMark = fnMark
                });
            }

            return View("ViewMarks", marksList);
        }

        // --- Course Registration ---
        [HttpGet]
        public IActionResult CourseRegistration()
        {
            ViewBag.Courses = new SelectList(_db.Courses, "Id", "Title");
            ViewBag.Fees = _db.FeeSettings.ToList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CourseRegistration(int courseId)
        {
            var sid = GetStudentId();
            if (sid == null) return RedirectToAction("StudentLogin", "Home");

            var course = await _db.Courses.FindAsync(courseId);
            var feeSetting = await _db.FeeSettings
                                      .FirstOrDefaultAsync(f => f.Semester == course!.Semester
                                                             && f.ExamYear == course.ExamYear);
            if (course == null || feeSetting == null)
                return BadRequest("Invalid course or fees not configured.");

            var reg = new Registration
            {
                StudentId = sid,
                CourseId = courseId,
                Fee = feeSetting.RegistrationFee,
                IsApproved = false,
                IsPaid = false
            };

            _db.Registrations.Add(reg);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(PayFee), new { id = reg.Id });
        }

        // --- Fee Payment ---
        [HttpGet]
        public async Task<IActionResult> PayFee(int id)
        {
            var reg = await _db.Registrations
                              .Include(r => r.Course)
                              .FirstOrDefaultAsync(r => r.Id == id);
            if (reg == null) return NotFound();
            return View(reg);
        }

        [HttpPost]
        public async Task<IActionResult> PayFee(int id, PaymentMethod method)
        {
            var reg = await _db.Registrations.FindAsync(id);
            if (reg == null) return NotFound();

            reg.IsPaid = true;
            _db.Payments.Add(new Payment
            {
                RegistrationId = id,
                Method = method,
                Amount = reg.Fee,
                PaidAt = DateTime.UtcNow
            });

            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Dashboard));
        }

        // --- Improvement Exams ---
        [HttpGet]
        public IActionResult ImprovementExam()
        {
            ViewBag.Courses = new SelectList(_db.Courses, "Id", "Title");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ImprovementExam(int courseId)
        {
            var sid = GetStudentId();
            if (sid == null) return RedirectToAction("StudentLogin", "Home");

            var course = await _db.Courses.FindAsync(courseId);
            var feeSetting = await _db.FeeSettings
                                        .FirstOrDefaultAsync(f => f.Semester == course!.Semester
                                                               && f.ExamYear == course.ExamYear);
            var registration = await _db.Registrations
                                        .FirstOrDefaultAsync(r => r.StudentId == sid && r.CourseId == courseId);
            if (course == null || feeSetting == null || registration == null)
                return BadRequest("Data missing or invalid.");

            var ie = new ImprovementExam
            {
                RegistrationId = registration.Id,
                Fee = feeSetting.ImprovementFee,
                IsApproved = false,
                IsPaid = false
            };

            _db.ImprovementExams.Add(ie);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(PayImprovementFee), new { id = ie.Id });
        }

        [HttpGet]
        public async Task<IActionResult> PayImprovementFee(int id)
        {
            var ie = await _db.ImprovementExams
                              .Include(i => i.Registration!)
                                .ThenInclude(r => r.Course!)
                              .FirstOrDefaultAsync(i => i.Id == id);
            if (ie == null) return BadRequest("Data missing.");
            return View(ie);
        }

        [HttpPost]
        public async Task<IActionResult> PayImprovementFee(int id, PaymentMethod method)
        {
            var ie = await _db.ImprovementExams.FindAsync(id);
            if (ie == null) return NotFound();

            ie.IsPaid = true;
            _db.Payments.Add(new Payment
            {
                RegistrationId = ie.RegistrationId,
                Method = method,
                Amount = ie.Fee,
                PaidAt = DateTime.UtcNow
            });

            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Dashboard));
        }

        // --- Progress (GPA %) ---
        public async Task<IActionResult> Progress()
        {
            var sid = GetStudentId();
            if (sid == null) return RedirectToAction("StudentLogin", "Home");

            var regs = await _db.Registrations
                                .Where(r => r.StudentId == sid && r.IsApproved)
                                .Include(r => r.Course)
                                .ToListAsync();

            var list = new List<StudentProgressViewModel>();

            foreach (var r in regs)
            {
                var a = await _db.Assessments
                                 .FirstOrDefaultAsync(x => x.RegistrationId == r.Id);

                var f = await _db.ExamReviews
                                 .Where(x => x.RegistrationId == r.Id)
                                 .MaxAsync(x => (int?)x.Mark) ?? 0;

                int maxAttend, maxPres, maxTest, maxFinal;
                switch (r.Course!.Type)
                {
                    case CourseType.Laboratory:
                        maxAttend = 10; maxPres = 10; maxTest = 10; maxFinal = 60;
                        break;
                    case CourseType.ProjectWork:
                        maxAttend = 30; maxPres = 40; maxTest = 30; maxFinal = 0;
                        break;
                    default:
                        maxAttend = 5; maxPres = 10; maxTest = 15; maxFinal = 70;
                        break;
                }

                var obtained = Math.Min(a?.AttendanceMark ?? 0, maxAttend)
                             + Math.Min(a?.PresentationMark ?? 0, maxPres)
                             + Math.Min(a?.ClassTestMark ?? 0, maxTest)
                             + Math.Min(f, maxFinal);

                var totalPossible = maxAttend + maxPres + maxTest + maxFinal;
                var pct = totalPossible > 0
                          ? (int)Math.Round(obtained * 100.0 / totalPossible)
                          : 0;

                list.Add(new StudentProgressViewModel
                {
                    Course = r.Course.Title,
                    Percentage = pct
                });
            }

            return View(list);
        }

        // --- NEW: My Registrations ---
        public async Task<IActionResult> MyRegistrations()
        {
            var sid = GetStudentId();
            if (sid == null) return RedirectToAction("StudentLogin", "Home");

            var regs = await _db.Registrations
                                .Where(r => r.StudentId == sid)
                                .Include(r => r.Course)
                                .ToListAsync();

            return View(regs);
        }
    }
}
