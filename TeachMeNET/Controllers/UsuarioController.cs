using Microsoft.AspNetCore.Mvc;
using TeachMeNET.Models;
using Microsoft.AspNetCore.Http;
using TeachMeNET.Models.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace TeachMeNET.Controllers
{
    public class UsuarioController: BaseController
    {
        private readonly TeachMeContext _context;
        public UsuarioController(TeachMeContext context)
        {
            this._context = context;
        }
    
        public IActionResult Registro()
        {
            ViewBag.Nombre = HttpContext.Session.GetString("UserName");
            return View();
        }

        [HttpPost]
        public IActionResult Registro(User model)
        {
            if (ModelState.IsValid)
            {
                //TempData["usuario"] = model;
                if (1 == 1)
                {
                    //User usuario = TempData["usuario"] as User;
                    if (model == null)
                    {
                        return RedirectToAction("Index","Home");
                    }
                    
                    _context.Add(model);
                    _context.SaveChanges();
                    HttpContext.Session.SetInt32("Id", model.Id);
                    HttpContext.Session.SetString("UserName", model.Name1);
                    return RedirectToAction("Index", "Home");
                }
            }
            //return RedirectToAction("Registro");
            return View(model);
        }
        
        public IActionResult Login()
		{
			return View();
		}

        [HttpPost]
        public IActionResult Login(InicioSesionModel inicio)
		{
            if(ModelState.IsValid){
                
                //aqui obtienes la lista de logins
                //var existeUsuario = _context.InicioSesiones.Any(u => u.Email == inicio.Email && u.Password == inicio.Password); //para ver si hay alguno que cumple con la condicion
                var usuario = _context
                                .InicioSesiones
                                .Include(i => i.User)
                                .FirstOrDefault(u => u.Email == inicio.Email && u.Password == inicio.Password);

                if (usuario == null) {
                    ModelState.AddModelError("Incorrecto", "contraseña incorrecta");
                }
                else {
                    HttpContext.Session.SetInt32("Id", usuario.User.Id);
                    HttpContext.Session.SetString("UserName", usuario.User.UserName);//hay un error aqui.
                    
                    return RedirectToAction("Index", "Home");
                }
                
            }
			return View(inicio);
		}

        public IActionResult ProcesarLogin(User model)
        {
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

		public IActionResult MiPerfil()
		{
			if (ViewBag.Id == null)
				return RedirectToAction("Index", "Home");
			else
				return View();
		}


        public IActionResult PerfilAlumno()
        {
            if (ViewBag.Id == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }
        public IActionResult PerfilProfesor()
        {
            if (ViewBag.Id == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                var profesores = _context
                                .Teachers
                                .FromSql("SELECT * FROM teachers")
                                .Where(b => b.UserId == HttpContext.Session.GetInt32("Id"))
                                .ToList()
                                .FirstOrDefault();
                if (profesores == null)
                {
                    var profesor = new Teacher();
                    profesor.UserId = (int) HttpContext.Session.GetInt32("Id");
                    _context.Add(profesor);
                    _context.SaveChanges();
                } else
                {
                    ViewBag.City = profesores.City;
                }
                return View();
            }   
               
        }
    }
}