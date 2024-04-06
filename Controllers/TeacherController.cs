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

                public async Task<IActionResult> Edit(int? id)
        {
            if(id == null) return NotFound();

            // var student = await _context.Students.FindAsync(id);
            var teacher = await _context
                                .Teachers
                                .FirstOrDefaultAsync(s => s.Id == id);
            if(teacher == null) return NotFound();

            return View(teacher);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, Teacher model)
        {
            if(id != model.Id) return NotFound();

            if(ModelState.IsValid)
            {
                try
                {
                    _context.Update(model);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if(!_context.Teachers.Any(s => s.Id == model.Id))
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}