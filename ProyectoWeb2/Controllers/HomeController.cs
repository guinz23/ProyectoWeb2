using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoWeb2.Models;
using Microsoft.AspNetCore.Http;

namespace ProyectoWeb2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ConexionContext _context;

        public HomeController(ConexionContext context) {

            _context = context;
        }
       

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Main()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpGet]
        public async Task<IActionResult>Index() => View(await _context.Usuarios.ToListAsync());
        [HttpPost]
        public async Task<IActionResult> Index(string usuario,string contraseña)
        {
            var usuarios = await _context.Usuarios.ToListAsync();
            for (int i = 0; i < usuarios.Count; i++)
            {
                if (usuarios[i].usuario == usuario && usuarios[i].contraseña == contraseña)
                {
                    HttpContext.Session.SetString("user", usuarios[i].usuario.ToString());
                    HttpContext.Session.SetString("rol", usuarios[i].rol.ToString());
                    //var x = HttpContext.Session.GetString("user");
                    
                    return View("Main");
                }
               
            }
            return View();
        }
    }
}
