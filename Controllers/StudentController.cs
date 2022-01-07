#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using School.Models;
using School.Services.Interfaces;

namespace School.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly IClassService _classService;
         private readonly ICountryService _countyService;
        public StudentController(IStudentService studentService, IClassService classService, ICountryService countyService)
        {
            _studentService = studentService;
            _classService = classService;
            _countyService = countyService;
        }

        // GET: Student
        public async Task<IActionResult> Index()
        {
            return View(_studentService.getAllStudents());
        }

        // GET: Student/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = _studentService.getStudent((int)id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: Student/Create
        public IActionResult Create()
        {
            ViewData["ClassesId"] = new SelectList(_classService.getAllClasses(), "id", "class_name");
            ViewData["CountriesId"] = new SelectList(_countyService.getAllCoiuntries(), "id", "name");
            return View();
        }

        // POST: Student/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,name,date_of_birth,ClassesId,CountriesId")] Student student)
        {
            if (ModelState.IsValid)
            {
                _studentService.addStudent(student);
                return RedirectToAction(nameof(Index));
            }
           ViewData["ClassesId"] = new SelectList(_classService.getAllClasses(), "id", "class_name", student.ClassesId);
            ViewData["CountriesId"] = new SelectList(_countyService.getAllCoiuntries(), "id", "name", student.CountriesId);
            return View(student);
        }

        // GET: Student/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = _studentService.getStudent((int)id);
            if (student == null)
            {
                return NotFound();
            }
            ViewData["ClassesId"] = new SelectList(_classService.getAllClasses(), "id", "class_name", student.ClassesId);
            ViewData["CountriesId"] = new SelectList(_countyService.getAllCoiuntries(), "id", "name", student.CountriesId);
            return View(student);
        }

        // POST: Student/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,name,date_of_birth,ClassesId,CountriesId")] Student student)
        {
            if (id != student.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _studentService.editStudent(student);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
             ViewData["ClassesId"] = new SelectList(_classService.getAllClasses(), "id", "class_name", student.ClassesId);
            ViewData["CountriesId"] = new SelectList(_countyService.getAllCoiuntries(), "id", "name", student.CountriesId);
            return View(student);
        }

        // GET: Student/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = _studentService.getStudent((int)id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _studentService.deleteStudent((int)id);
            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(int id)
        {
            return _studentService.StudentExists((int)id);
        }
    }
}
