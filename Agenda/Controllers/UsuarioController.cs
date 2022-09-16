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
         
        public ActionResult Details(int id)
        {
            var usuario =  _context.Usuarios.FirstAsync(u => u.Id == id);
            return View(usuario);
        }
         
        public ActionResult Create()
        {
            return View();
        } 

        [HttpPost]
        public ActionResult Create(Usuario usuario)
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
         
        public ActionResult Edit(int id)
        {
            var usuario = _context.Usuarios.FirstAsync(u => u.Id == id);
            return View(usuario);
        }
         
        [HttpPost]
        public ActionResult Edit(int id, Usuario usuario)
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
         
        public ActionResult Delete(int id)
        {
            return View();
        }
         
        [HttpPost]
        public ActionResult Delete(Usuario usuario)
        {
            try
            {
                _context.Usuarios.Remove(usuario);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
