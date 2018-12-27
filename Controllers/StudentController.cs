using KimiNoGakko.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace KimiNoGakko.Controllers
{
    public class StudentController : Controller
    {

        private readonly SchoolContext _context;

        public StudentController(SchoolContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> List(int? page, string searchString, string sortOrder, string currentFilter)
        {
            ViewData["CurrentSort"] = sortOrder;

            ViewData["LastNameSort"] = String.IsNullOrEmpty(sortOrder) ? "LastName_desc" : "";

            ViewData["FirstMidNameSort"] = sortOrder == "FirstMidName" ? "FirstMidName_desc" : "FirstMidName";


            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            var students = from s in _context.Students
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                students = students.Where(s =>
                    s.LastName.Contains(searchString) || s.FirstMidName.Contains(searchString));
            }

            if (string.IsNullOrEmpty(sortOrder))
            {
                sortOrder = "LastName";
            }

            bool descending = false;
            if (sortOrder.EndsWith("_desc"))
            {
                sortOrder = sortOrder.Substring(0, sortOrder.Length - 5);
                descending = true;
            }

            if (descending)
            {
                students = students.OrderByDescending(e => EF.Property<object>(e, sortOrder));
            }
            else
            {
                students = students.OrderBy(e => EF.Property<object>(e, sortOrder));
            }

            int pageSize = 7;
            return View(await PaginatedList<Student>.CreateAsync(students,
                page ?? 1, pageSize));
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Student student)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(student);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("List");
                }
            }
            catch (Exception /*ex*/)
            {
                ModelState.AddModelError("", "Unable to save changes" + "Server side model problem");
            }

            return View(student);
        }

        public IActionResult Details(int? id)
        {
            return View(_context.Students.Find(id));
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = _context.Students.Find(id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students.FindAsync(id);

            if (await TryUpdateModelAsync<Student>(student, "", s => s.FirstMidName, s => s.LastName, s => s.BirthDate, s => s.GudrdianPhoneNumber, s => s.Pesel))
            {
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction("List");
                }
                catch (Exception /* ex */)
                {
                    ModelState.AddModelError("", "Unable to save changes" + "Server side model problem");
                }
            }

            return View(student);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students
                .AsNoTracking()
                .FirstOrDefaultAsync(s => s.ID == id);

            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students
                .AsNoTracking()
                .FirstOrDefaultAsync(s => s.ID == id);

            if (student == null)
            {
                return RedirectToAction("List");
            }

            try
            {
                _context.Students.Remove(student);
                await _context.SaveChangesAsync();
                return RedirectToAction("List");
            }
            catch (DbUpdateException ex)
            {
                ViewData["ErrorMessage"] = "Error with processing data to delete";
                return RedirectToAction("Delete");
            }
        }

    }
}