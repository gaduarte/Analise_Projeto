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
    public class BookController : Controller
    {
        private readonly MyDbContext _context;

        public BookController(MyDbContext context)
        {
            _context = context;
        }

        // GET: Book
        public async Task<IActionResult> Index()
        {
            var myDbContext = _context.Books.Include(b => b.Catalog).Include(b => b.Member);
            return View(await myDbContext.ToListAsync());
        }

        // GET: Book/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var books = await _context.Books
                .Include(b => b.Catalog)
                .Include(b => b.Member)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (books == null)
            {
                return NotFound();
            }

            return View(books);
        }

        // GET: Book/Create
        public IActionResult Create()
        {
            ViewData["CatalogId"] = new SelectList(_context.Catalogs, "Id", "Id");
            ViewData["MemberId"] = new SelectList(_context.Members, "Id", "Id");
            return View();
        }

        // POST: Book/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AuthorName,BookName,NoofBooks,CatalogId,MemberId")] Books books)
        {
            if (ModelState.IsValid)
            {
                _context.Add(books);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CatalogId"] = new SelectList(_context.Catalogs, "Id", "Id", books.CatalogId);
            ViewData["MemberId"] = new SelectList(_context.Members, "Id", "Id", books.MemberId);
            return View(books);
        }

        // GET: Book/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var books = await _context.Books.FindAsync(id);
            if (books == null)
            {
                return NotFound();
            }
            ViewData["CatalogId"] = new SelectList(_context.Catalogs, "Id", "Id", books.CatalogId);
            ViewData["MemberId"] = new SelectList(_context.Members, "Id", "Id", books.MemberId);
            return View(books);
        }

        // POST: Book/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("Id,AuthorName,BookName,NoofBooks,CatalogId,MemberId")] Books books)
        {
            if (id != books.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(books);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BooksExists(books.Id))
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
            ViewData["CatalogId"] = new SelectList(_context.Catalogs, "Id", "Id", books.CatalogId);
            ViewData["MemberId"] = new SelectList(_context.Members, "Id", "Id", books.MemberId);
            return View(books);
        }

        // GET: Book/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var books = await _context.Books
                .Include(b => b.Catalog)
                .Include(b => b.Member)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (books == null)
            {
                return NotFound();
            }

            return View(books);
        }

        // POST: Book/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var books = await _context.Books.FindAsync(id);
            _context.Books.Remove(books);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BooksExists(int? id)
        {
            return _context.Books.Any(e => e.Id == id);
        }
    }
}
