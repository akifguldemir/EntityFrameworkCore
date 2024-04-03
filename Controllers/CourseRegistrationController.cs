using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using EntityFrameworkCore.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EntityFrameworkCore.Controllers
{
    public class CourseRegistrationController : Controller
    {
        private readonly ILogger<CourseRegistrationController> _logger;
        private readonly DataContext _context;

        public CourseRegistrationController(DataContext context, ILogger<CourseRegistrationController> logger)
        {
            _logger = logger;
            _context = context;

        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.allStudents = new SelectList(await _context.Students.ToListAsync(), "Id", "Name");
            ViewBag.allCourses = new SelectList(await _context.Courses.ToListAsync(), "Id", "Title");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}