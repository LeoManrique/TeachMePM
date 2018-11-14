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

            var people = _context
                                .Teachers
                                .Where(u => HttpContext.Request.Query["curso"].ToString() == "" ||
                                       u.Topic1 == HttpContext.Request.Query["curso"].ToString())
                                .Where(u => HttpContext.Request.Query["lugar"].ToString() == "" ||
                                       u.City == HttpContext.Request.Query["lugar"].ToString())
                                .Where(u => (HttpContext.Request.Query["domicilioa"].ToString() == "" &&
                                            HttpContext.Request.Query["domiciliop"].ToString() == "" &&
                                            HttpContext.Request.Query["lugarp"].ToString() == "" &&
                                            HttpContext.Request.Query["online"].ToString() == "") ||
                                            (u.ToHouse && HttpContext.Request.Query["domicilioa"].ToString() == "1") ||
                                            (u.MyHouse && HttpContext.Request.Query["domiciliop"].ToString() == "1") ||
                                            (u.PublicSpace && HttpContext.Request.Query["lugarp"].ToString() == "1") ||
                                            (u.Online && HttpContext.Request.Query["online"].ToString() == "1")
                                            )
                                .Join(_context.Users, teacher => teacher.UserId, user => user.Id,
                                (teacher, user) => new
                                { teacher, user } );
            List<List<Object>> person = new List<List<Object>>();

            foreach (var i in people)
            {
                List<Object> list = new List<Object>();
                list.Add(i.user.Name1);//0
                list.Add(i.user.LastName1);
                list.Add(i.user.Id);
                list.Add(i.teacher.Country);
                list.Add(i.teacher.City);//4
                list.Add(i.teacher.AboutMe);
                list.Add(i.teacher.Topic1);//6
                list.Add(i.teacher.Price1);
                list.Add(i.teacher.ToHouse);//8
                list.Add(i.teacher.MyHouse);
                list.Add(i.teacher.PublicSpace);//10
                list.Add(i.teacher.Online);
                person.Add(list);
            }

            ViewBag.Personas = person;
            ViewBag.Curso = HttpContext.Request.Query["curso"].ToString();
            ViewBag.Lugar = HttpContext.Request.Query["lugar"].ToString();

            ViewBag.DomicilioA = HttpContext.Request.Query["domicilioa"].ToString();
            ViewBag.DomicilioP = HttpContext.Request.Query["domiciliop"].ToString();
            ViewBag.LugarP = HttpContext.Request.Query["lugarp"].ToString();
            ViewBag.Virtual = HttpContext.Request.Query["online"].ToString();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
