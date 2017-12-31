using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieMaster.Data;
using MovieMaster.Models;
namespace MovieMaster.Controllers
{
    public class AdressesController : Controller
    {
        private readonly MovieMasterContext _context;
        public AdressesController(MovieMasterContext context) => _context = context;
        // GET: Adresses
        public IActionResult CreateCustomerAdress(string customer) => new CustomerAdressViewModel
            {
                Customer = _context.Customer.Cast<Customer>().Single(cust => cust.CustomerId == customer),
                Adress = _context.Adress.FirstOrDefault(adress => adress.CustomerId == customer)
            }.Adress == null ? base.View("Create", new Adress() { CustomerId = customer}) : base.View("Details", new CustomerAdressViewModel
            {
                Customer = _context.Customer.Cast<Customer>().Single(cust => cust.CustomerId == customer),
                Adress = _context.Adress.FirstOrDefault(adress => adress.CustomerId == customer)
            });
        // POST: Adresses/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AdressId,CustomerId,Street,City,ZipCode,Country")] Adress adress)
        {
            if (!ModelState.IsValid) return View(adress);
            _context.Add(adress);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index","Customers");
        }
        // GET: Adresses/Edit/5
        public async Task<IActionResult> Edit(string customer) => View(await _context.Adress.SingleOrDefaultAsync(m => m.CustomerId == customer));
        // POST: Adresses/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("AdressId,CustomerId,Street,City,ZipCode,Country")] Adress adress)
        {
            if (!ModelState.IsValid) return View(adress);
            try
            {
                _context.Update(adress);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdressExists(adress.AdressId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction("index", "Customers");
        }
        // GET: Adresses/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adress = await _context.Adress
                .SingleOrDefaultAsync(m => m.AdressId == id);
            if (adress == null)
            {
                return NotFound();
            }

            return RedirectToAction("index", "Customers");
        }
        // POST: Adresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var adress = await _context.Adress.SingleOrDefaultAsync(m => m.AdressId == id);
            _context.Adress.Remove(adress);
            await _context.SaveChangesAsync();
            return RedirectToAction("index", "Customers"); ;
        }
        private bool AdressExists(string id)
        {
            return _context.Adress.Any(e => e.AdressId == id);
        }
    }
}
