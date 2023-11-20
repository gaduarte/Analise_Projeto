#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using biblioteca_trabalho.Models;

namespace biblioteca_trabalho.Controllers
{
    public class GeneralBookController : Controller
    {
        private readonly MyDbContext _context;

        public GeneralBookController(MyDbContext context)
        {
            _context = context;
        }

        // GET: GeneralBook
        public async Task<IActionResult> Index()
        {
            var myDbContext = _context.GeneralBook.Include(g => g.Catalog).Include(g => g.Member);
            return View(await myDbContext.ToListAsync());
        }

        // GET: GeneralBook/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var generalBook = await _context.GeneralBook
                .Include(g => g.Catalog)
                .Include(g => g.Member)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (generalBook == null)
            {
                return NotFound();
            }

            return View(generalBook);
        }

        // GET: GeneralBook/Create
        public IActionResult Create()
        {
            ViewData["CatalogId"] = new SelectList(_context.Catalogs, "Id", "Id");
            ViewData["MemberId"] = new SelectList(_context.Members, "Id", "Id");
            return View();
        }

        // POST: GeneralBook/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AuthorName,BookName,NoofBooks,CatalogId,MemberId")] GeneralBook generalBook)
        {
            if (ModelState.IsValid)
            {
                _context.Add(generalBook);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CatalogId"] = new SelectList(_context.Catalogs, "Id", "Id", generalBook.CatalogId);
            ViewData["MemberId"] = new SelectList(_context.Members, "Id", "Id", generalBook.MemberId);
            return View(generalBook);
        }

        // GET: GeneralBook/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var generalBook = await _context.GeneralBook.FindAsync(id);
            if (generalBook == null)
            {
                return NotFound();
            }
            ViewData["CatalogId"] = new SelectList(_context.Catalogs, "Id", "Id", generalBook.CatalogId);
            ViewData["MemberId"] = new SelectList(_context.Members, "Id", "Id", generalBook.MemberId);
            return View(generalBook);
        }

        // POST: GeneralBook/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("Id,AuthorName,BookName,NoofBooks,CatalogId,MemberId")] GeneralBook generalBook)
        {
            if (id != generalBook.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(generalBook);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GeneralBookExists(generalBook.Id))
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
            ViewData["CatalogId"] = new SelectList(_context.Catalogs, "Id", "Id", generalBook.CatalogId);
            ViewData["MemberId"] = new SelectList(_context.Members, "Id", "Id", generalBook.MemberId);
            return View(generalBook);
        }

        // GET: GeneralBook/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var generalBook = await _context.GeneralBook
                .Include(g => g.Catalog)
                .Include(g => g.Member)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (generalBook == null)
            {
                return NotFound();
            }

            return View(generalBook);
        }

        // POST: GeneralBook/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var generalBook = await _context.GeneralBook.FindAsync(id);
            _context.GeneralBook.Remove(generalBook);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GeneralBookExists(int? id)
        {
            return _context.GeneralBook.Any(e => e.Id == id);
        }
    }
}
