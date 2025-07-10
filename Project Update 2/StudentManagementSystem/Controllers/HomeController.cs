using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using StudentManagementSystem.Data;
using StudentManagementSystem.Models;
using StudentManagementSystem.Models.Academic;
using StudentManagementSystem.Models.Finance;

namespace StudentManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly AppDbContext _db;

        public HomeController(AppDbContext db, IConfiguration configuration)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public IActionResult Index() => View();

        public IActionResult Privacy() => View();

        [HttpGet]
        public IActionResult StudentRegistration()
            => View(new StudentRegistrationViewModel());

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> StudentRegistration(StudentRegistrationViewModel vm)
        {
            // CAPTCHA check
            if (vm.CaptchaCode != vm.CaptchaInput)
                ModelState.AddModelError(nameof(vm.CaptchaInput), "CAPTCHA does not match.");

            if (!vm.DateOfBirth.HasValue)
                ModelState.AddModelError(nameof(vm.DateOfBirth), "Date of Birth is required.");

            if (!ModelState.IsValid)
                return View(vm);

            // Save uploaded photo
            var uploads = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");
            if (!Directory.Exists(uploads))
                Directory.CreateDirectory(uploads);

            var photoName = $"{vm.StudentId}_{Path.GetFileName(vm.Photo.FileName)}";
            var filePath = Path.Combine(uploads, photoName);
            using (var fs = new FileStream(filePath, FileMode.Create))
                await vm.Photo.CopyToAsync(fs);

            // Hash password
            using var sha = SHA256.Create();
            var hashStr = Convert.ToBase64String(sha.ComputeHash(Encoding.UTF8.GetBytes(vm.Password)));

            var student = new Student
            {
                StudentId = vm.StudentId,
                FirstName = vm.FirstName,
                MiddleName = vm.MiddleName,
                LastName = vm.LastName,
                NickName = vm.NickName,
                FatherName = vm.FatherName,
                MotherName = vm.MotherName,
                GurdianName = vm.GurdianName,
                DateOfBirth = vm.DateOfBirth.Value,
                Gender = vm.Gender,
                PhoneNumber = vm.PhoneNumber,
                Email = vm.Email,
                PasswordHash = hashStr,
                PhotoFileName = photoName,
                IsApproved = false,
                IsDenied = false
            };

            _db.Students.Add(student);
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(RegistrationSuccess));
        }

        public IActionResult RegistrationSuccess() => View();

        [HttpGet]
        public IActionResult StudentLogin()
        {
            if (TempData["Info"] != null)
                ViewBag.Info = TempData["Info"];
            return View(new StudentLoginViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> StudentLogin(StudentLoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            // Hash input password
            using var sha = SHA256.Create();
            var hashStr = Convert.ToBase64String(sha.ComputeHash(Encoding.UTF8.GetBytes(model.Password)));

            // Attempt login
            var student = await _db.Students
                                   .FirstOrDefaultAsync(s =>
                                        (s.StudentId == model.Identifier || s.Email == model.Identifier)
                                        && s.PasswordHash == hashStr);

            if (student == null)
            {
                ModelState.AddModelError("", "Invalid credentials.");
                return View(model);
            }

            if (!student.IsApproved)
            {
                var msg = student.IsDenied
                    ? "Your registration was denied. Please register again."
                    : "Account not yet approved by admin.";
                ModelState.AddModelError("", msg);
                return View(model);
            }

            // Set session
            HttpContext.Session.SetString("StudentId", student.StudentId);
            HttpContext.Session.SetString("StudentName", student.FirstName);
            HttpContext.Session.SetString("UserRole", "Student");

            return RedirectToAction(nameof(Dashboard));
        }

        public IActionResult Dashboard()
        {
            var studentId = HttpContext.Session.GetString("StudentId");
            if (string.IsNullOrEmpty(studentId))
                return RedirectToAction(nameof(StudentLogin));

            var student = _db.Students
                             .AsNoTracking()
                             .FirstOrDefault(s => s.StudentId == studentId);
            if (student == null)
                return RedirectToAction(nameof(StudentLogin));

            ViewBag.StudentName = student.FirstName;
            ViewBag.StudentId = student.StudentId;
            ViewBag.StudentEmail = student.Email;
            ViewBag.StudentStatus = student.IsApproved;
            ViewBag.PhotoPath = Url.Content($"~/uploads/{student.PhotoFileName}");

            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            TempData["Info"] = "Logged out successfully.";
            return RedirectToAction(nameof(StudentLogin));
        }

        [HttpGet]
        public IActionResult AdminLogin()
            => View(new AdminLoginViewModel());

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AdminLogin(AdminLoginViewModel model)
        {
            var adminUsername = _configuration["AdminCredentials:Username"];
            var adminPasswordHash = _configuration["AdminCredentials:PasswordHash"];

            using var sha = SHA256.Create();
            var inputHash = Convert.ToBase64String(sha.ComputeHash(Encoding.UTF8.GetBytes(model.Password)));

            if (model.Username == adminUsername && inputHash == adminPasswordHash)
            {
                HttpContext.Session.SetString("IsAdmin", "True");
                HttpContext.Session.SetString("UserRole", "Admin");
                return RedirectToAction(nameof(AdminDashboard));
            }

            ModelState.AddModelError("", "Invalid admin credentials.");
            return View(model);
        }

        public IActionResult AdminLogout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> ApproveStudents()
        {
            if (HttpContext.Session.GetString("IsAdmin") != "True")
                return RedirectToAction(nameof(Index));

            var pending = await _db.Students
                                   .Where(s => !s.IsApproved && !s.IsDenied)
                                   .ToListAsync();
            return View(pending);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Approve(string id)
        {
            var student = await _db.Students.FindAsync(id);
            if (student != null)
            {
                student.IsApproved = true;
                student.IsDenied = false;
                await _db.SaveChangesAsync();
            }
            return RedirectToAction(nameof(ApproveStudents));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Deny(string id)
        {
            var student = await _db.Students.FindAsync(id);
            if (student != null)
            {
                _db.Students.Remove(student);
                await _db.SaveChangesAsync();
            }
            return RedirectToAction(nameof(ApproveStudents));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NotApprove(string id)
        {
            var student = await _db.Students.FindAsync(id);
            if (student != null)
            {
                student.IsApproved = false;
                student.IsDenied = true;
                await _db.SaveChangesAsync();
            }
            return RedirectToAction(nameof(ApproveStudents));
        }

        [HttpGet]
        public async Task<IActionResult> ViewStudent(string id)
        {
            var s = await _db.Students.FindAsync(id);
            if (s == null) return NotFound();
            return View(s);
        }

        public IActionResult AdminDashboard()
        {
            if (HttpContext.Session.GetString("IsAdmin") != "True")
                return RedirectToAction(nameof(Index));

            var facultyList = _db.Faculty.ToList();
            return View(new { FacultyList = facultyList });
        }

        [HttpGet]
        public IActionResult FacultyLogin()
            => View(new FacultyLoginViewModel());

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> FacultyLogin(FacultyLoginViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            using var sha = SHA256.Create();
            var hashStr = Convert.ToBase64String(sha.ComputeHash(Encoding.UTF8.GetBytes(model.Password)));

            var faculty = await _db.Faculty
                                   .FirstOrDefaultAsync(f =>
                                        (f.FacultyId == model.Identifier || f.Email == model.Identifier)
                                        && f.PasswordHash == hashStr);

            if (faculty == null)
            {
                ModelState.AddModelError("", "Invalid credentials.");
                return View(model);
            }

            HttpContext.Session.SetString("FacultyId", faculty.FacultyId);
            HttpContext.Session.SetString("FacultyName", faculty.Name);
            HttpContext.Session.SetString("UserRole", "Faculty");

            return RedirectToAction(nameof(FacultyDashboard));
        }

        public IActionResult FacultyLogout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction(nameof(FacultyLogin));
        }

        public IActionResult FacultyDashboard()
        {
            var facultyId = HttpContext.Session.GetString("FacultyId");
            if (string.IsNullOrEmpty(facultyId))
                return RedirectToAction(nameof(FacultyLogin));

            var faculty = _db.Faculty.FirstOrDefault(f => f.FacultyId == facultyId);
            if (faculty == null)
                return RedirectToAction(nameof(FacultyLogin));

            ViewBag.FacultyName = faculty.Name;
            ViewBag.FacultyId = faculty.FacultyId;
            ViewBag.FacultyEmail = faculty.Email;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddFaculty(AddFacultyViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            using var sha = SHA256.Create();
            var hash = Convert.ToBase64String(sha.ComputeHash(Encoding.UTF8.GetBytes(model.Password)));

            var faculty = new Faculty
            {
                FacultyId = model.FacultyId,
                Name = model.Name,
                Email = model.Email,
                PasswordHash = hash
            };

            _db.Faculty.Add(faculty);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(AdminDashboard));
        }

        [HttpGet]
        public IActionResult ChangePassword() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            // Hash both
            using var sha = SHA256.Create();
            var currentHash = Convert.ToBase64String(sha.ComputeHash(Encoding.UTF8.GetBytes(model.CurrentPassword)));
            var newHash = Convert.ToBase64String(sha.ComputeHash(Encoding.UTF8.GetBytes(model.NewPassword)));

            // Student password change?
            var stud = await _db.Students.FirstOrDefaultAsync(s => s.StudentId == HttpContext.Session.GetString("StudentId"));
            if (stud != null)
            {
                if (stud.PasswordHash != currentHash)
                {
                    ModelState.AddModelError("", "Invalid current password.");
                    return View(model);
                }
                stud.PasswordHash = newHash;
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Dashboard));
            }

            // Faculty password change?
            var fac = await _db.Faculty.FirstOrDefaultAsync(f => f.FacultyId == HttpContext.Session.GetString("FacultyId"));
            if (fac != null)
            {
                if (fac.PasswordHash != currentHash)
                {
                    ModelState.AddModelError("", "Invalid current password.");
                    return View(model);
                }
                fac.PasswordHash = newHash;
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(FacultyDashboard));
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
