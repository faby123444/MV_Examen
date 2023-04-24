using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MV_Examen.Data;
using MV_Examen.Models;

namespace MV_Examen.Controllers
{
    public class VR_FabianaController : Controller
    {
        private readonly MV_ExamenContext _context;

        public VR_FabianaController(MV_ExamenContext context)
        {
            _context = context;
        }

        // GET: VR_Fabiana
        public async Task<IActionResult> Index()
        {
              return _context.VR_Fabiana != null ? 
                          View(await _context.VR_Fabiana.ToListAsync()) :
                          Problem("Entity set 'MV_ExamenContext.VR_Fabiana'  is null.");
        }

        // GET: VR_Fabiana/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.VR_Fabiana == null)
            {
                return NotFound();
            }

            var vR_Fabiana = await _context.VR_Fabiana
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vR_Fabiana == null)
            {
                return NotFound();
            }

            return View(vR_Fabiana);
        }

        // GET: VR_Fabiana/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VR_Fabiana/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idv,Puestovr,Id")] VR_Fabiana vR_Fabiana)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vR_Fabiana);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vR_Fabiana);
        }

        // GET: VR_Fabiana/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.VR_Fabiana == null)
            {
                return NotFound();
            }

            var vR_Fabiana = await _context.VR_Fabiana.FindAsync(id);
            if (vR_Fabiana == null)
            {
                return NotFound();
            }
            return View(vR_Fabiana);
        }

        // POST: VR_Fabiana/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idv,Puestovr,Id")] VR_Fabiana vR_Fabiana)
        {
            if (id != vR_Fabiana.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vR_Fabiana);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VR_FabianaExists(vR_Fabiana.Id))
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
            return View(vR_Fabiana);
        }

        // GET: VR_Fabiana/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.VR_Fabiana == null)
            {
                return NotFound();
            }

            var vR_Fabiana = await _context.VR_Fabiana
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vR_Fabiana == null)
            {
                return NotFound();
            }

            return View(vR_Fabiana);
        }

        // POST: VR_Fabiana/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.VR_Fabiana == null)
            {
                return Problem("Entity set 'MV_ExamenContext.VR_Fabiana'  is null.");
            }
            var vR_Fabiana = await _context.VR_Fabiana.FindAsync(id);
            if (vR_Fabiana != null)
            {
                _context.VR_Fabiana.Remove(vR_Fabiana);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VR_FabianaExists(int id)
        {
          return (_context.VR_Fabiana?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
