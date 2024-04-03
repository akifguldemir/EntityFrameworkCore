using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EntityFrameworkCore.Data
{
    public class CourseController : Controller
    {
        private readonly ILogger<CourseController> _logger;
        private readonly DataContext _context;

        public CourseController(DataContext context, ILogger<CourseController> logger)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await  _context.Courses.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if(id == null) return NotFound();

            var course = await _context.Courses.FindAsync(id);
            if(course == null) return NotFound();

            return View(course);
        }
         
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, Course model)
        {
            if(id != model.Id) return NotFound();

            if(ModelState.IsValid)
            {
                try
                {
                    _context.Update(model);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException)
                {
                    if(!_context.Courses.Any(s => s.Id == model.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Course course)
        {
            _context.Courses.Add(course);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

           [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if(id == null) return NotFound();

            var course = await _context.Courses.FirstOrDefaultAsync(c => c.Id == id);
            if(course == null) return NotFound();

            return View(course);
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromForm]int id)
        {
            var course = await _context.Courses.FindAsync(id);
            if(course == null) return NotFound();

            _context.Courses.Remove(course);
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