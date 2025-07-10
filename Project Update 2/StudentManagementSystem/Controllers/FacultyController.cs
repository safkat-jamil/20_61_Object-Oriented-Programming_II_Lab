using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Data;
using StudentManagementSystem.Models.Academic;

namespace StudentManagementSystem.Controllers
{
    public class FacultyController : Controller
    {
        private readonly AppDbContext _db;
        public FacultyController(AppDbContext db) => _db = db;

        public IActionResult FacultyDashboard() => View();

        public IActionResult AddAttendance() => RedirectToAction(nameof(AddCallRecords));
        public IActionResult AddMarks() => RedirectToAction(nameof(AddAssessmentMarks));

        public IActionResult AddCallRecords() => View();

        // GET: AddAssessmentMarks?courseId=123
        [HttpGet]
        public async Task<IActionResult> AddAssessmentMarks(int courseId)
        {
            // Include Student navigation property, then filter by courseId and approval
            var regs = await _db.Registrations
                                .Include(r => r.Student)
                                .Where(r => r.CourseId == courseId && r.IsApproved)
                                .ToListAsync();

            ViewBag.CourseId = courseId;
            return View(regs);
        }

        // POST: AddAssessmentMarks
        [HttpPost]
        public async Task<IActionResult> AddAssessmentMarks(int courseId, List<Assessment> marks)
        {
            if (ModelState.IsValid)
            {
                foreach (var a in marks)
                {
                    _db.Assessments.Add(a);
                }
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(FacultyDashboard));
            }

            // If invalid, re-fetch registrations to re-display form
            var regs = await _db.Registrations
                                .Include(r => r.Student)
                                .Where(r => r.CourseId == courseId && r.IsApproved)
                                .ToListAsync();
            ViewBag.CourseId = courseId;
            return View(regs);
        }

        public IActionResult ViewClassRoutine() => View();
        public IActionResult ViewFinalExamRoutine() => View();
        public IActionResult ViewRegisteredStudents() => View();
        public IActionResult ViewPendingStudents() => View();

        public IActionResult AddStudyMaterial()
        {
            ViewBag.Courses = new SelectList(_db.Courses, "Id", "Title");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddStudyMaterial(int courseId, IFormFile file)
        {
            if (file?.Length > 0)
            {
                var uploads = Path.Combine("wwwroot", "materials");
                Directory.CreateDirectory(uploads);
                var fn = $"{Guid.NewGuid()}_{file.FileName}";
                using var fs = new FileStream(Path.Combine(uploads, fn), FileMode.Create);
                await file.CopyToAsync(fs);

                _db.StudyMaterials.Add(new StudyMaterial
                {
                    CourseId = courseId,
                    FilePath = $"/materials/{fn}",
                    UploadedAt = DateTime.UtcNow
                });
                await _db.SaveChangesAsync();
            }
            return RedirectToAction(nameof(FacultyDashboard));
        }

        public IActionResult AddClassRoutine()
        {
            ViewBag.Courses = new SelectList(_db.Courses, "Id", "Title");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddClassRoutine(Routine m)
        {
            if (ModelState.IsValid)
            {
                m.Type = RoutineType.Class;
                _db.Routines.Add(m);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(ViewClassRoutine));
            }
            ViewBag.Courses = new SelectList(_db.Courses, "Id", "Title");
            return View(m);
        }

        public IActionResult AddTestRoutine()
        {
            ViewBag.Courses = new SelectList(_db.Courses, "Id", "Title");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddTestRoutine(Routine m)
        {
            if (ModelState.IsValid)
            {
                m.Type = RoutineType.Test;
                _db.Routines.Add(m);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(ViewClassRoutine));
            }
            ViewBag.Courses = new SelectList(_db.Courses, "Id", "Title");
            return View(m);
        }

        public IActionResult AddPresentationRoutine()
        {
            ViewBag.Courses = new SelectList(_db.Courses, "Id", "Title");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddPresentationRoutine(Routine m)
        {
            if (ModelState.IsValid)
            {
                m.Type = RoutineType.Presentation;
                _db.Routines.Add(m);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(ViewClassRoutine));
            }
            ViewBag.Courses = new SelectList(_db.Courses, "Id", "Title");
            return View(m);
        }
    }
}
