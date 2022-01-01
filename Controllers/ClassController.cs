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
    public class ClassController : Controller
    {
        // private readonly MvcSchoolContext _context;
        private readonly IClassService _classService;

        public ClassController(IClassService classService)
        {
            _classService = classService;
        }

        // GET: Class
        public async Task<IActionResult> Index()
        {
            return View(_classService.getAllClasses());
        }

        // GET: Class/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @class = _classService.getClass((int)id);
            if (@class == null)
            {
                return NotFound();
            }

            return View(@class);
        }

        // GET: Class/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Class/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,class_name")] Class @class)
        {
            if (ModelState.IsValid)
            {
                _classService.addClass(@class);
                return RedirectToAction(nameof(Index));
            }
            return View(@class);
        }

        // GET: Class/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @class = _classService.getClass((int)id);
            if (@class == null)
            {
                return NotFound();
            }
            return View(@class);
        }

        // POST: Class/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,class_name")] Class @class)
        {
            if (id != @class.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _classService.editClass(@class);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClassExists(@class.id))
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
            return View(@class);
        }

        // GET: Class/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @class =  _classService.getClass((int)id);
            if (@class == null)
            {
                return NotFound();
            }

            return View(@class);
        }

        // POST: Class/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _classService.deleteClass(id);
            return RedirectToAction(nameof(Index));
        }

        private bool ClassExists(int id)
        {
            return _classService.classExists(id);
        }
    }
}
