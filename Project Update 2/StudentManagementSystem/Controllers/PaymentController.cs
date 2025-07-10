using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.Data;
using StudentManagementSystem.Models.Academic;

public class PaymentController : Controller
{
    private readonly AppDbContext _db;
    public PaymentController(AppDbContext db) => _db = db;

    // GET: /Payment/OfflineInstructions
    public IActionResult OfflineInstructions()
        => View();  // Explain bank transfer details

    // GET: /Payment/Bkash
    public IActionResult Bkash() => View();   // Placeholder

    // GET: /Payment/Nagad
    public IActionResult Nagad() => View();   // Placeholder

    // GET: /Payment/Rocket
    public IActionResult Rocket() => View();  // Placeholder
}
