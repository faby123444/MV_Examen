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
    public class MF_VasconezController : Controller
    {
        private readonly MV_ExamenContext _context;

        public MF_VasconezController(MV_ExamenContext context)
        {
            _context = context;
        }

        // GET: MF_Vasconez
        public async Task<IActionResult> Index()
        {
              return _context.MF_Vasconez != null ? 
                          View(await _context.MF_Vasconez.ToListAsync()) :
                          Problem("Entity set 'MV_ExamenContext.MF_Vasconez'  is null.");
        }

        // GET: MF_Vasconez/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MF_Vasconez == null)
            {
                return NotFound();
            }

            var mF_Vasconez = await _context.MF_Vasconez
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mF_Vasconez == null)
            {
                return NotFound();
            }

            return View(mF_Vasconez);
        }

        // GET: MF_Vasconez/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MF_Vasconez/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Salariomf,Nombremf,Activomf,Cumpleañosmf,Idv")] MF_Vasconez mF_Vasconez)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mF_Vasconez);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mF_Vasconez);
        }

        // GET: MF_Vasconez/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MF_Vasconez == null)
            {
                return NotFound();
            }

            var mF_Vasconez = await _context.MF_Vasconez.FindAsync(id);
            if (mF_Vasconez == null)
            {
                return NotFound();
            }
            return View(mF_Vasconez);
        }

        // POST: MF_Vasconez/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Salariomf,Nombremf,Activomf,Cumpleañosmf,Idv")] MF_Vasconez mF_Vasconez)
        {
            if (id != mF_Vasconez.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mF_Vasconez);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MF_VasconezExists(mF_Vasconez.Id))
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
            return View(mF_Vasconez);
        }

        // GET: MF_Vasconez/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MF_Vasconez == null)
            {
                return NotFound();
            }

            var mF_Vasconez = await _context.MF_Vasconez
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mF_Vasconez == null)
            {
                return NotFound();
            }

            return View(mF_Vasconez);
        }

        // POST: MF_Vasconez/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MF_Vasconez == null)
            {
                return Problem("Entity set 'MV_ExamenContext.MF_Vasconez'  is null.");
            }
            var mF_Vasconez = await _context.MF_Vasconez.FindAsync(id);
            if (mF_Vasconez != null)
            {
                _context.MF_Vasconez.Remove(mF_Vasconez);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MF_VasconezExists(int id)
        {
          return (_context.MF_Vasconez?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
