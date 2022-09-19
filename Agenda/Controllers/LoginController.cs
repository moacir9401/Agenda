using Agenda.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Security.Principal;

namespace Agenda.Controllers
{
    public class LoginController : Controller
    {
        private readonly Context _context;

        public LoginController(Context context)
        {
            _context = context;
        }

        public async Task<ActionResult> Index()
        {

            await HttpContext.SignOutAsync();
            return View();
        }


        [HttpPost]
        public async Task<ActionResult> Logar(Usuario user)
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Nome == user.Nome && u.Senha == user.Senha);

            if (usuario == null)
            {
                ViewData["msgError"] = "Login ou senha Invalido";
                return View(nameof(Index));
            }

            var claims = new List<Claim>
            {

                new Claim(ClaimTypes.Name, usuario.Nome),
                new Claim(ClaimTypes.Email, usuario.Email),
                new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),

            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            ClaimsPrincipal principal = new ClaimsPrincipal(claimsIdentity);

            await HttpContext.SignInAsync(principal);

            return RedirectToAction("Index", "Home");
        }

    }
}
