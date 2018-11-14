using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace TeachMeNET.Controllers
{
    public class BaseController : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
			var id = HttpContext.Session.GetInt32("Id");

			var username = HttpContext.Session.GetString("UserName");
            var nombre = HttpContext.Session.GetString("FirstName");
            var apellido = HttpContext.Session.GetString("LastName");

            ViewBag.Nombre = username;
			ViewBag.Id = id;
            ViewBag.UName = nombre;
            ViewBag.ULastName = apellido;

        }
    }
}