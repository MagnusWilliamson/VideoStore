using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieMaster.Data;
using MovieMaster.Models;
namespace MovieMaster.Controllers
{
    public class MoviesController : Controller
    {
        private readonly MovieMasterContext _context;
        public MoviesController(MovieMasterContext context) =>_context = context;
        // GET: Movies
        public async Task<IActionResult> Index()=>View(await _context.Movie.ToListAsync());
        // GET: Movies/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null) return NotFound();
            var movie = await _context.Movie
                .SingleOrDefaultAsync(m => m.MovieId == id);
            if (movie == null) return NotFound();
            return View(movie);
        }
        // GET: Movies/Create
        public IActionResult Create() => View();
        // POST: Movies/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MovieId,Titel,AgeLimit,Genre,Price,Description,ReleaseDate")] Movie movie)
        {
            if (!ModelState.IsValid) return View(movie);
            _context.Add(movie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        // GET: Movies/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null) return NotFound();
            var movie = await _context.Movie.SingleOrDefaultAsync(m => m.MovieId == id);
            if (movie == null) return NotFound();
            return View(movie);
        }
        // POST: Movies/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MovieId,Titel,AgeLimit,Genre,Price,Description,ReleaseDate")] Movie movie)
        {
            if (id != movie.MovieId) return NotFound();
            if (!ModelState.IsValid) return View(movie);
            try
            {
                _context.Update(movie);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieExists(movie.MovieId))
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
        // GET: Movies/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null) return NotFound();
            var movie = await _context.Movie
                .SingleOrDefaultAsync(m => m.MovieId == id);
            if (movie == null) return NotFound();
            return View(movie);
        }
        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var movie = await _context.Movie.SingleOrDefaultAsync(m => m.MovieId == id);
            _context.Movie.Remove(movie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private bool MovieExists(string id) => _context.Movie.Any(e => e.MovieId == id);
        public async Task<IActionResult> TitelSort() => View("index",await (from movie in _context.Movie orderby movie.Titel select movie).ToListAsync());
        public async Task<IActionResult> AgeSort() => View("index", await (from movie in _context.Movie orderby movie.AgeLimit select movie).ToListAsync());
        public async Task<IActionResult> GenreSort() => View("index", await (from movie in _context.Movie orderby movie.Genre select movie).ToListAsync());
        public async Task<IActionResult> PriceSort() => View("index", await (from movie in _context.Movie orderby movie.Price select movie).ToListAsync());
        public async Task<IActionResult> DescriptionSort() => View("index", await (from movie in _context.Movie orderby movie.Description select movie).ToListAsync());
        public async Task<IActionResult> ReleaseDateSort() => View("index", await (from movie in _context.Movie orderby movie.ReleaseDate select movie).ToListAsync());

    }
}
