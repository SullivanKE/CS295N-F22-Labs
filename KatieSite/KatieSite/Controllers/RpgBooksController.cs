using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KatieSite.Data;
using KatieSite.Models;

namespace KatieSite.Controllers
{
    public class RpgBooksController : Controller
    {
        private readonly RpgDbContext _context;

        public RpgBooksController(RpgDbContext context)
        {
            _context = context;
        }

        // GET: RpgBooks
        public async Task<IActionResult> Index()
        {
              return View(await _context.RpgBooks
                  .Include(book => book.PublishedBy)
                  .ToListAsync());
        }

        // GET: RpgBooks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.RpgBooks == null)
            {
                return NotFound();
            }

            var rpgBook = await _context.RpgBooks
				  .Include(book => book.PublishedBy)
				.FirstOrDefaultAsync(m => m.Id == id);
            if (rpgBook == null)
            {
                return NotFound();
            }

            return View(rpgBook);
        }

        // GET: RpgBooks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RpgBooks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Published")] RpgBook rpgBook)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rpgBook);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rpgBook);
        }

        // GET: RpgBooks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.RpgBooks == null)
            {
                return NotFound();
            }

            var rpgBook = await _context.RpgBooks
				  .Include(book => book.PublishedBy)
                  .Where(book => book.Id == id)
                  .SingleOrDefaultAsync();
            if (rpgBook == null)
            {
                return NotFound();
            }
            return View(rpgBook);
        }

        // POST: RpgBooks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Published")] RpgBook rpgBook)
        {
            if (id != rpgBook.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rpgBook);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RpgBookExists(rpgBook.Id))
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
            return View(rpgBook);
        }

        // GET: RpgBooks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.RpgBooks == null)
            {
                return NotFound();
            }

            var rpgBook = await _context.RpgBooks
				  .Include(book => book.PublishedBy)
				.FirstOrDefaultAsync(m => m.Id == id);
            if (rpgBook == null)
            {
                return NotFound();
            }

            return View(rpgBook);
        }

        // POST: RpgBooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.RpgBooks == null)
            {
                return Problem("Entity set 'RpgDbContext.RpgBooks'  is null.");
            }
            var rpgBook = await _context.RpgBooks
				  .Include(book => book.PublishedBy)
				  .Where(book => book.Id == id)
				  .SingleOrDefaultAsync();

			if (rpgBook != null)
            {
                _context.RpgBooks.Remove(rpgBook);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RpgBookExists(int id)
        {
          return _context.RpgBooks.Any(e => e.Id == id);
        }
    }
}
