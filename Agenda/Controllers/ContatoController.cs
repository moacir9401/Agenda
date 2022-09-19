using Agenda.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Agenda.Controllers
{
    [Authorize]
    public class ContatoController : Controller
    {
        private readonly Context _context;

        public ContatoController(Context context)
        {
            _context = context;
        }

        [HttpGet("Contato")]
        public async Task<ActionResult> Index()
        {
            var contatos = await _context.Contatos.ToListAsync();

            return View(contatos);
        }
         
        [HttpGet]
        public async Task<ActionResult> VisualizarContato(long id)
        {
            var contato = await _context.Contatos.FirstAsync(u => u.Id == id);
            return View(contato);
        }

        [HttpGet]
        public ActionResult CriarContato()
        {
            return View();
        } 

        [HttpPost]
        public ActionResult CriarContato(Contato contato)
        {
            try
            { 
                _context.Add(contato);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public async Task<ActionResult> EditarContato(int id)
        {
            var contato = await _context.Contatos.FirstAsync(u => u.Id == id);
            return View(contato);
        }
         
        [HttpPost]
        public ActionResult EditarContato(int id, Contato contato)
        {
            try
            {
                _context.Contatos.Update(contato);                  
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
          
         
        [HttpGet]
        public async Task<ActionResult> ExcluirContato(int id)
        {
            try
            {
                var contato = await _context.Contatos.FirstAsync(u => u.Id == id);
                _context.Contatos.Remove(contato);
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
