using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Assignment2.Models;
using Assignment2.Data;
using Microsoft.EntityFrameworkCore;

namespace Assignment2.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext _context;

    public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var books = await _context.Book.ToListAsync();
        return View(books);
    }

    public async Task<IActionResult> Books()
    {
        var books = await _context.Book.ToListAsync();
        return View(books);
    }


    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Contact()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
