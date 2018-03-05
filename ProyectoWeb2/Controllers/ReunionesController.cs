using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoWeb2;
using ProyectoWeb2.Models;

namespace ProyectoWeb2.Controllers
{
    public class ReunionesController : Controller
    {
        private readonly ConexionContext _context;

        public ReunionesController(ConexionContext context)
        {
            _context = context;
        }

        // GET: Reuniones
        public async Task<IActionResult> Index()
        {
            var conexionContext = _context.Reuniones.Include(r => r.Cliente).Include(r => r.Usuario);
            return View(await conexionContext.ToListAsync());
        }

        // GET: Reuniones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reuniones = await _context.Reuniones
                .Include(r => r.Cliente)
                .Include(r => r.Usuario)
                .SingleOrDefaultAsync(m => m.id == id);
            if (reuniones == null)
            {
                return NotFound();
            }

            return View(reuniones);
        }

        // GET: Reuniones/Create
        public IActionResult Create()
        {
            ViewData["Clienteid"] = new SelectList(_context.Clientes, "id", "Nombre");
            ViewData["Usuarioid"] = new SelectList(_context.Usuarios, "id", "usuario");
            return View();
        }

        // POST: Reuniones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Título_reunión,Fecha_Hora,Usuarioid,Clienteid")] Reuniones reuniones)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reuniones);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Clienteid"] = new SelectList(_context.Clientes, "id", "Nombre", reuniones.Clienteid);
            ViewData["Usuarioid"] = new SelectList(_context.Usuarios, "id", "usuario", reuniones.Usuarioid);
            return View(reuniones);
        }

        // GET: Reuniones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reuniones = await _context.Reuniones.SingleOrDefaultAsync(m => m.id == id);
            if (reuniones == null)
            {
                return NotFound();
            }
            ViewData["Clienteid"] = new SelectList(_context.Clientes, "id", "Nombre", reuniones.Clienteid);
            ViewData["Usuarioid"] = new SelectList(_context.Usuarios, "id", "usuario", reuniones.Usuarioid);
            return View(reuniones);
        }

        // POST: Reuniones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Título_reunión,Fecha_Hora,Usuarioid,Clienteid")] Reuniones reuniones)
        {
            if (id != reuniones.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reuniones);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReunionesExists(reuniones.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["Clienteid"] = new SelectList(_context.Clientes, "id", "Nombre", reuniones.Clienteid);
            ViewData["Usuarioid"] = new SelectList(_context.Usuarios, "id", "usuario", reuniones.Usuarioid);
            return View(reuniones);
        }

        // GET: Reuniones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reuniones = await _context.Reuniones
                .Include(r => r.Cliente)
                .Include(r => r.Usuario)
                .SingleOrDefaultAsync(m => m.id == id);
            if (reuniones == null)
            {
                return NotFound();
            }

            return View(reuniones);
        }

        // POST: Reuniones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reuniones = await _context.Reuniones.SingleOrDefaultAsync(m => m.id == id);
            _context.Reuniones.Remove(reuniones);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReunionesExists(int id)
        {
            return _context.Reuniones.Any(e => e.id == id);
        }
    }
}
