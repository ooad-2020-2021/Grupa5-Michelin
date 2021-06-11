using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Michelin.Data;
using Michelin.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Michelin.Controllers
{
    public class ZahtjeviZaPomocController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<Korisnik> _userManager;

        public ZahtjeviZaPomocController(ApplicationDbContext context, UserManager<Korisnik> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: ZahtjeviZaPomoc
        public async Task<IActionResult> Index()
        {
            var zahtjevi = await _context.ZahtjevZaPomoc.ToListAsync();
            zahtjevi.RemoveAll((z) => z.obradjeno == true);

            return View(zahtjevi);
        }

        public async Task<IActionResult> Greska()
        {
            return View();
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
        public async Task<IActionResult> Create([Bind("kategorija,sadrzaj")] ZahtjevZaPomoc zahtjevZaPomoc)
        {
            //if(ModelState.IsValid)
            {
                var id = User.FindFirst(ClaimTypes.NameIdentifier);
                Korisnik korisnik = await _userManager.GetUserAsync(User);
                zahtjevZaPomoc.obradjeno = false;
                zahtjevZaPomoc.korisnik = korisnik;
                _context.Add(zahtjevZaPomoc);
                await _context.SaveChangesAsync();

                return RedirectToAction("SviRecepti", "Home");
            }
            return RedirectToAction("Greska");
        }

        public async  void Obradi(string id)
        {
            var zahtjevZaPomoc = await _context.ZahtjevZaPomoc.FindAsync(id);
            zahtjevZaPomoc.obradjeno = true;
            _context.Update(zahtjevZaPomoc);
            await _context.SaveChangesAsync();

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
