using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Domain;
using WebApp.Data;

namespace WebApp.Controllers
{
    public class RsaKeysController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RsaKeysController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RsaKeys
        public async Task<IActionResult> Index()
        {
            return View(await _context.RsaKeys.ToListAsync());
        }

        // GET: RsaKeys/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rsaKey = await _context.RsaKeys
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rsaKey == null)
            {
                return NotFound();
            }

            return View(rsaKey);
        }

        // GET: RsaKeys/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RsaKeys/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RsaKey rsaKey)
        {
            if (ModelState.IsValid)
            {
                Crypto.Rsa.RsaImplemantation(rsaKey);
                _context.Add(rsaKey);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rsaKey);
        }
        
        // GET: RsaKeys/Create
        public IActionResult Decrypt()
        {
            return View();
        }

        // POST: RsaKeys/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Decrypt(RsaKey rsaKey)
        {
            if (ModelState.IsValid)
            {
                Crypto.Rsa.RsaDecrypt(rsaKey);
                _context.Add(rsaKey);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rsaKey);
        }

        // GET: RsaKeys/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rsaKey = await _context.RsaKeys.FindAsync(id);
            if (rsaKey == null)
            {
                return NotFound();
            }
            return View(rsaKey);
        }

        // POST: RsaKeys/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, RsaKey rsaKey)
        {
            if (id != rsaKey.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Crypto.Rsa.RsaImplemantation(rsaKey);
                    _context.Update(rsaKey);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RsaKeyExists(rsaKey.Id))
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
            return View(rsaKey);
        }

        // GET: RsaKeys/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rsaKey = await _context.RsaKeys
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rsaKey == null)
            {
                return NotFound();
            }

            return View(rsaKey);
        }

        // POST: RsaKeys/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rsaKey = await _context.RsaKeys.FindAsync(id);
            _context.RsaKeys.Remove(rsaKey);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RsaKeyExists(int id)
        {
            return _context.RsaKeys.Any(e => e.Id == id);
        }
    }
}
