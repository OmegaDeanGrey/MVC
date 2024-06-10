using Microsoft.AspNetCore.Mvc;
using Liberation.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Liberation.Controllers
{
    public class NoteController : Controller
    {
        private readonly LiberationDbContext _context;

        public NoteController(LiberationDbContext context)
        {
            _context = context;
        }

        // GET: Note/Index
        public async Task<IActionResult> Index()
        {
            var notey = await _context.Note.ToListAsync();
            return View(notey);
        }

        // GET: Note/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Note/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Note")] NoteModel noteModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(noteModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(noteModel);
        }
    




       // GET: Note/Edit/5
public async Task<IActionResult> Edit(int? id)
{
    if (id == null)
    {
        return NotFound();
    }

    var noteModel = await _context.Note.FindAsync(id);
    if (noteModel == null)
    {
        return NotFound();
    }
    return View(noteModel);
}

// POST: Note/Edit/5
[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Note")] NoteModel noteModel)
{
    if (id != noteModel.Id)
    {
        return NotFound();
    }

    if (ModelState.IsValid)
    {
        try
        {
            _context.Update(noteModel);
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!NoteModelExists(noteModel.Id))
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
    return View(noteModel);
}
    


// POST: Note/Delete/5
[HttpPost, ActionName("Delete")]
[ValidateAntiForgeryToken]
public async Task<IActionResult> DeleteConfirmed(int id)
{
    var noteModel = await _context.Note.FindAsync(id);
    _context.Note.Remove(noteModel);
    await _context.SaveChangesAsync();
    return RedirectToAction(nameof(Index));
}

private bool NoteModelExists(int id)
{
    return _context.Note.Any(e => e.Id == id);
}

}}