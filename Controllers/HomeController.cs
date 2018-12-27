using KimiNoGakko.Models;
using Microsoft.AspNetCore.Mvc;

namespace KimiNoGakko.Controllers
{
    public class HomeController : Controller
    {
        private readonly SchoolContext _context;

        public HomeController(SchoolContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

    }
}