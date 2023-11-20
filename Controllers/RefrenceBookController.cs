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
    public class RefrenceBookController : Controller
    {
        private readonly MyDbContext _context;

        public RefrenceBookController(MyDbContext context)
        {
            _context = context;
        }

        // GET: RefrenceBook
        public async Task<IActionResult> Index()
        {
            var myDbContext = _context.RefrenceBook.Include(r => r.Catalog).Include(r => r.Member);
            return View(await myDbContext.ToListAsync());
        }

        // GET: RefrenceBook/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var refrenceBook = await _context.RefrenceBook
                .Include(r => r.Catalog)
                .Include(r => r.Member)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (refrenceBook == null)
            {
                return NotFound();
            }

            return View(refrenceBook);
        }

        // GET: RefrenceBook/Create
        public IActionResult Create()
        {
            ViewData["CatalogId"] = new SelectList(_context.Catalogs, "Id", "Id");
            ViewData["MemberId"] = new SelectList(_context.Members, "Id", "Id");
            return View();
        }

        // POST: RefrenceBook/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AuthorName,BookName,NoofBooks,CatalogId,MemberId")] RefrenceBook refrenceBook)
        {
            if (ModelState.IsValid)
            {
                _context.Add(refrenceBook);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CatalogId"] = new SelectList(_context.Catalogs, "Id", "Id", refrenceBook.CatalogId);
            ViewData["MemberId"] = new SelectList(_context.Members, "Id", "Id", refrenceBook.MemberId);
            return View(refrenceBook);
        }

        // GET: RefrenceBook/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var refrenceBook = await _context.RefrenceBook.FindAsync(id);
            if (refrenceBook == null)
            {
                return NotFound();
            }
            ViewData["CatalogId"] = new SelectList(_context.Catalogs, "Id", "Id", refrenceBook.CatalogId);
            ViewData["MemberId"] = new SelectList(_context.Members, "Id", "Id", refrenceBook.MemberId);
            return View(refrenceBook);
        }

        // POST: RefrenceBook/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("Id,AuthorName,BookName,NoofBooks,CatalogId,MemberId")] RefrenceBook refrenceBook)
        {
            if (id != refrenceBook.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(refrenceBook);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RefrenceBookExists(refrenceBook.Id))
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
            ViewData["CatalogId"] = new SelectList(_context.Catalogs, "Id", "Id", refrenceBook.CatalogId);
            ViewData["MemberId"] = new SelectList(_context.Members, "Id", "Id", refrenceBook.MemberId);
            return View(refrenceBook);
        }

        // GET: RefrenceBook/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var refrenceBook = await _context.RefrenceBook
                .Include(r => r.Catalog)
                .Include(r => r.Member)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (refrenceBook == null)
            {
                return NotFound();
            }

            return View(refrenceBook);
        }

        // POST: RefrenceBook/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var refrenceBook = await _context.RefrenceBook.FindAsync(id);
            _context.RefrenceBook.Remove(refrenceBook);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RefrenceBookExists(int? id)
        {
            return _context.RefrenceBook.Any(e => e.Id == id);
        }
    }
}
