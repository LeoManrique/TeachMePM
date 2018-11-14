using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TeachMeNET.Models;

namespace TeachMeNET.Controllers
{
    public class HomeController : BaseController
    {
        private readonly TeachMeContext _context;
        public HomeController(TeachMeContext context)
        {
            this._context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Busqueda()
        {
            var teachers = _context
                                .Teachers
                                .ToList();
            ViewBag.Teachers = teachers;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
