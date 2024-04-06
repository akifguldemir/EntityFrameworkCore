using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using EntityFrameworkCore.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EntityFrameworkCore.Controllers
{
    public class TeacherController : Controller
    {
        private readonly DataContext _context;
        private readonly ILogger<StudentController> _logger;

        public TeacherController(DataContext context, ILogger<StudentController> logger)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await  _context.Teachers.ToListAsync());
        }

        
        public IActionResult Create()
        {
            return View();
        }

        public async Task<IActionResult> Add(Teacher teacher)
        {
            _context.Teachers.Add(teacher);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}