using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieMaster.Data;
using MovieMaster.Models;
namespace MovieMaster.Controllers
{
    public class CustomersController : Controller
    {
        private readonly MovieMasterContext _context;
        public CustomersController(MovieMasterContext context) =>_context = context;
        // GET: Customers
        public async Task<IActionResult> Index() => View(await _context.Customer.ToListAsync());
        // GET: Customers/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null) return NotFound();
            var customer = await _context.Customer
                .SingleOrDefaultAsync(m => m.CustomerId == id);
            if (customer == null) return NotFound();
            return View(customer);
        }
        // GET: Customers/Create
        public IActionResult Create() => View();
        // POST: Customers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustomerId,Active,FirstName,LastName")] Customer customer)
        {
            if (!ModelState.IsValid) return View(customer);
            _context.Add(customer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        // GET: Customers/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null) return NotFound();
            var customer = await _context.Customer.SingleOrDefaultAsync(m => m.CustomerId == id);
            if (customer == null) return NotFound();
            return View(customer);
        }
        // POST: Customers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("CustomerId,Active,FirstName,LastName")] Customer customer)
        {
            if (id != customer.CustomerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(customer.CustomerId))
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
            return View(customer);
        }
        // GET: Customers/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customer
                .SingleOrDefaultAsync(m => m.CustomerId == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }
        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var customer = await _context.Customer.SingleOrDefaultAsync(m => m.CustomerId == id);
            _context.Customer.Remove(customer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private bool CustomerExists(string id)
        {
            return _context.Customer.Any(e => e.CustomerId == id);
        }
        public IActionResult FirstNameSort() =>View("Index",(from customer in _context.Customer orderby customer.FirstName select customer));
        public IActionResult LastNameSort() => View("Index", (from customer in _context.Customer orderby customer.LastName select customer));
        public IActionResult ActiveSort() => View("Index", (from customer in _context.Customer orderby customer.Active select customer));
    }
}
