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

            ViewBag.Nombre = username;
			ViewBag.Id = id;
		}
    }
}