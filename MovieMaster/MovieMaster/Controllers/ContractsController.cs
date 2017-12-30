using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieMaster.Data;
using MovieMaster.Models;
namespace MovieMaster.Controllers
{
    public class ContractsController : Controller
    {
        private readonly MovieMasterContext _context;
        public ContractsController(MovieMasterContext context)
        {
            _context = context;
        }
        // GET: Contracts
        public IActionResult Index() => View(_context.Contract.Join(_context.Customer, customer=> customer.CustomerId,
            contract => contract.CustomerId,
            (contract, customer) => new ContractViewModel()
            {
                CustomerName = customer.FirstName +" " + customer.LastName,
                ContractId = contract.ContractId,
                CustomerId = contract.MovieId,
                FromDate = contract.FromDate,
                ToDate = contract.ToDate,
                ReturnDate = contract.ReturnDate,
                MovieId = contract.MovieId
            }));
        // GET: Contracts/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contract = await _context.Contract
                .SingleOrDefaultAsync(m => m.ContractId == id);
            if (contract == null)
            {
                return NotFound();
            }

            return View(contract);
        }
        // GET: Contracts/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contract = await _context.Contract.SingleOrDefaultAsync(m => m.ContractId == id);
            if (contract == null)
            {
                return NotFound();
            }
            return View(contract);
        }
        // POST: Contracts/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ContractId,MovieId,CustomerId,FromDate,ToDate,ReturnDate")] Contract contract)
        {
            if (id != contract.ContractId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contract);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContractExists(contract.ContractId))
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
            return View(contract);
        }
        // GET: Contracts/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contract = await _context.Contract
                .SingleOrDefaultAsync(m => m.ContractId == id);
            if (contract == null)
            {
                return NotFound();
            }

            return View(contract);
        }
        // POST: Contracts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var contract = await _context.Contract.SingleOrDefaultAsync(m => m.ContractId == id);
            _context.Contract.Remove(contract);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult CustSort() =>
            View("Index", from contract in (_context.Contract.Join(_context.Customer, customer => customer.CustomerId,
                    contract => contract.CustomerId,
                    (contract, customer) => new ContractViewModel()
                    {
                        CustomerName = customer.FirstName + " " + customer.LastName,
                        ContractId = contract.ContractId,
                        CustomerId = contract.MovieId,
                        FromDate = contract.FromDate,
                        ToDate = contract.ToDate,
                        ReturnDate = contract.ReturnDate,
                        MovieId = contract.MovieId
                    }))
                orderby contract.CustomerName
                select contract);
        public IActionResult ReturnDateSort() =>
            View("Index", from contract in (_context.Contract.Join(_context.Customer, customer => customer.CustomerId,
                    contract => contract.CustomerId,
                    (contract, customer) => new ContractViewModel()
                    {
                        CustomerName = customer.FirstName + " " + customer.LastName,
                        ContractId = contract.ContractId,
                        CustomerId = contract.MovieId,
                        FromDate = contract.FromDate,
                        ToDate = contract.ToDate,
                        ReturnDate = contract.ReturnDate,
                        MovieId = contract.MovieId
                    })) orderby contract.ReturnDate select contract);
        public IActionResult ToDateSort() =>
            View("Index", from contract in (_context.Contract.Join(_context.Customer, customer => customer.CustomerId,
                    contract => contract.CustomerId,
                    (contract, customer) => new ContractViewModel()
                    {
                        CustomerName = customer.FirstName + " " + customer.LastName,
                        ContractId = contract.ContractId,
                        CustomerId = contract.MovieId,
                        FromDate = contract.FromDate,
                        ToDate = contract.ToDate,
                        ReturnDate = contract.ReturnDate,
                        MovieId = contract.MovieId
                    }))
                orderby contract.ToDate
                select contract);
        public IActionResult FromDateSort() =>
            View("Index", from contract in (_context.Contract.Join(_context.Customer, customer => customer.CustomerId,
                    contract => contract.CustomerId,
                    (contract, customer) => new ContractViewModel()
                    {
                        CustomerName = customer.FirstName + " " + customer.LastName,
                        ContractId = contract.ContractId,
                        CustomerId = contract.MovieId,
                        FromDate = contract.FromDate,
                        ToDate = contract.ToDate,
                        ReturnDate = contract.ReturnDate,
                        MovieId = contract.MovieId
                    }))
                orderby contract.FromDate
                select contract);
        private bool ContractExists(string id)
        {
            return _context.Contract.Any(e => e.ContractId == id);
        }
    }
}
