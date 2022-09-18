using Agenda.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Agenda.Controllers
{
    public class LoginController : Controller
    {
        private readonly Context _context;

        public LoginController(Context context)
        {
            _context = context;
        }

        [HttpGet("Login")]
        public async Task<ActionResult> Index()
        {
            return View();
        }


        [HttpPost]
        public async Task<ActionResult> Logar(Usuario model)
        { 
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Nome == model.Nome && u.Senha == model.Senha);

            if (usuario == null)
            {
                ViewData["msgError"] = "Login ou senha Invalido";
                return View(nameof(Index));
            }

            
            return RedirectToAction("Index", "Home");
        }

    }
}
