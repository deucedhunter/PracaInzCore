using KimiNoGakko.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace KimiNoGakko.Controllers
{
    public class InstructorController : Controller
    {

        private readonly SchoolContext _context;

        public InstructorController(SchoolContext context)
        {
            _context = context;
        }

        public IActionResult List()
        {
            return View(_context.Instructors.AsNoTracking().ToList());
        }
    }
}