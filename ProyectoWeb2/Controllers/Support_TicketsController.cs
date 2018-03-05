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
    public class Support_TicketsController : Controller
    {
        private readonly ConexionContext _context;

        public Support_TicketsController(ConexionContext context)
        {
            _context = context;
        }

        // GET: Support_Tickets
        public async Task<IActionResult> Index()
        {
            var conexionContext = _context.Support_Tickets.Include(s => s.Cliente);
            return View(await conexionContext.ToListAsync());
        }

        // GET: Support_Tickets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var support_Tickets = await _context.Support_Tickets
                .Include(s => s.Cliente)
                .SingleOrDefaultAsync(m => m.id == id);
            if (support_Tickets == null)
            {
                return NotFound();
            }

            return View(support_Tickets);
        }

        // GET: Support_Tickets/Create
        public IActionResult Create()
        {
            ViewData["Clienteid"] = new SelectList(_context.Clientes, "id", "Nombre");
            return View();
        }

        // POST: Support_Tickets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Título_Problema,Detalle_del_problema,Quién_reporta_el_problema,Clienteid,Estado_actual")] Support_Tickets support_Tickets)
        {
            if (ModelState.IsValid)
            {
                _context.Add(support_Tickets);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Clienteid"] = new SelectList(_context.Clientes, "id", "Nombre", support_Tickets.Clienteid);
            return View(support_Tickets);
        }

        // GET: Support_Tickets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var support_Tickets = await _context.Support_Tickets.SingleOrDefaultAsync(m => m.id == id);
            if (support_Tickets == null)
            {
                return NotFound();
            }
            ViewData["Clienteid"] = new SelectList(_context.Clientes, "id", "Nombre", support_Tickets.Clienteid);
            return View(support_Tickets);
        }

        // POST: Support_Tickets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Título_Problema,Detalle_del_problema,Quién_reporta_el_problema,Clienteid,Estado_actual")] Support_Tickets support_Tickets)
        {
            if (id != support_Tickets.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(support_Tickets);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Support_TicketsExists(support_Tickets.id))
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
            ViewData["Clienteid"] = new SelectList(_context.Clientes, "id", "Nombre", support_Tickets.Clienteid);
            return View(support_Tickets);
        }

        // GET: Support_Tickets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var support_Tickets = await _context.Support_Tickets
                .Include(s => s.Cliente)
                .SingleOrDefaultAsync(m => m.id == id);
            if (support_Tickets == null)
            {
                return NotFound();
            }

            return View(support_Tickets);
        }

        // POST: Support_Tickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var support_Tickets = await _context.Support_Tickets.SingleOrDefaultAsync(m => m.id == id);
            _context.Support_Tickets.Remove(support_Tickets);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Support_TicketsExists(int id)
        {
            return _context.Support_Tickets.Any(e => e.id == id);
        }
    }
}
