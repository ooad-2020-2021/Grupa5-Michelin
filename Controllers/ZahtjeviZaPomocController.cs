using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Michelin.Data;
using Michelin.Models;

namespace Michelin.Controllers
{
    public class ZahtjeviZaPomocController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ZahtjeviZaPomocController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ZahtjeviZaPomoc
        public async Task<IActionResult> Index()
        {
            return View(await _context.ZahtjevZaPomoc.ToListAsync());
        }

        // GET: ZahtjeviZaPomoc/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zahtjevZaPomoc = await _context.ZahtjevZaPomoc
                .FirstOrDefaultAsync(m => m.id == id);
            if (zahtjevZaPomoc == null)
            {
                return NotFound();
            }

            return View(zahtjevZaPomoc);
        }

        // GET: ZahtjeviZaPomoc/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ZahtjeviZaPomoc/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,kategorija,sadrzaj,obradjeno")] ZahtjevZaPomoc zahtjevZaPomoc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(zahtjevZaPomoc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(zahtjevZaPomoc);
        }

        // GET: ZahtjeviZaPomoc/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zahtjevZaPomoc = await _context.ZahtjevZaPomoc.FindAsync(id);
            if (zahtjevZaPomoc == null)
            {
                return NotFound();
            }
            return View(zahtjevZaPomoc);
        }

        // POST: ZahtjeviZaPomoc/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("id,kategorija,sadrzaj,obradjeno")] ZahtjevZaPomoc zahtjevZaPomoc)
        {
            if (id != zahtjevZaPomoc.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(zahtjevZaPomoc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZahtjevZaPomocExists(zahtjevZaPomoc.id))
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
            return View(zahtjevZaPomoc);
        }

        // GET: ZahtjeviZaPomoc/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zahtjevZaPomoc = await _context.ZahtjevZaPomoc
                .FirstOrDefaultAsync(m => m.id == id);
            if (zahtjevZaPomoc == null)
            {
                return NotFound();
            }

            return View(zahtjevZaPomoc);
        }

        // POST: ZahtjeviZaPomoc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var zahtjevZaPomoc = await _context.ZahtjevZaPomoc.FindAsync(id);
            _context.ZahtjevZaPomoc.Remove(zahtjevZaPomoc);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ZahtjevZaPomocExists(string id)
        {
            return _context.ZahtjevZaPomoc.Any(e => e.id == id);
        }
    }
}
