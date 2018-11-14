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
                                .Teachers;
            var users = _context
                                .Users;

            var personas = teachers.Join(users,
                            teacher => teacher.UserId,
                            user => user.Id,
                            (teacher, user) => new
                            {
                                UserId = user.Id,
                                Name = user.Name1,
                                LastName = user.LastName1,
                                About = teacher.AboutMe,
                                City = teacher.City,
                                Country = teacher.Country,
                                Price = teacher.Price1,

                            }
                            ).GroupBy(record => record.UserId);

            ViewBag.Personas = personas; 

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
