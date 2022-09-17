using Agenda.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Agenda.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly Context _context;

        public UsuarioController(Context context)
        {
            _context = context;
        }

        [HttpGet("Usuario")]
        public async Task<ActionResult> Index()
        {
            var usuarios = await _context.Usuarios.ToListAsync();

            return View(usuarios);
        }
         
        [HttpGet]
        public async Task<ActionResult> VisualizarUsuario(long id)
        {
            var usuario = await _context.Usuarios.FirstAsync(u => u.Id == id);
            return View(usuario);
        }

        [HttpGet]
        public ActionResult CriarUsuario()
        {
            return View();
        } 

        [HttpPost]
        public ActionResult CriarUsuario(Usuario usuario)
        {
            try
            { 
                _context.Add(usuario);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public async Task<ActionResult> EditarUsuario(int id)
        {
            var usuario = await _context.Usuarios.FirstAsync(u => u.Id == id);
            return View(usuario);
        }
         
        [HttpPost]
        public ActionResult EditarUsuario(int id, Usuario usuario)
        {
            try
            {
                _context.Usuarios.Update(usuario);                  
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
          
         
        [HttpGet]
        public async Task<ActionResult> ExcluirUsuario(int id)
        {
            try
            {
                var usuario = await _context.Usuarios.FirstAsync(u => u.Id == id);
                _context.Usuarios.Remove(usuario);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
