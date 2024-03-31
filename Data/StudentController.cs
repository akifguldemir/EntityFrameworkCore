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
    public class StudentController : Controller
    {
        private readonly DataContext _context;
        private readonly ILogger<StudentController> _logger;

        public StudentController(DataContext context, ILogger<StudentController> logger)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Create()
        {
            return View();
        }

        public async Task<IActionResult> Add(Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        
        public async Task<IActionResult> Index()
        {
            return View(await  _context.Students.ToListAsync());
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if(id == null) return NotFound();

            // var student = await _context.Students.FindAsync(id);
            var student = await _context.Students.FirstOrDefaultAsync(s => s.Id == id);
            if(student == null) return NotFound();

            return View(student);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, Student model)
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
                    if(!_context.Students.Any(s => s.Id == model.Id))
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