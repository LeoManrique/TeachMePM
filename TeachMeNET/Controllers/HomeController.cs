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
            var users = _context
                                .Users
                                .ToList();

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
                            )
                            .FirstOrDefault();

            var people = _context
                                .Teachers
                                .Join(_context.Users, teacher => teacher.UserId, user => user.Id,
                                (teacher, user) => new
                                { teacher, user } );
            List<List<Object>> person = new List<List<Object>>();
            foreach (var i in people)
            {
                List<Object> list = new List<Object>();
                list.Add(i.user.Name1);
                list.Add(i.user.LastName1);
                list.Add(i.user.Id);
                list.Add(i.teacher.Country);
                list.Add(i.teacher.City);
                list.Add(i.teacher.AboutMe);
                list.Add(i.teacher.Topic1);
                list.Add(i.teacher.Price1);
                person.Add(list);
            }

            ViewBag.Personas = person; 

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
