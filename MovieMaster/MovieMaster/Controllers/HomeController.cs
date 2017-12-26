using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MovieMaster.Models;
using MovieMaster.Data;
using System.Threading.Tasks;

namespace MovieMaster.Controllers
{
    public class HomeController : Controller
    {
        private readonly MovieMasterContext _context;
        public HomeController(MovieMasterContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> CreateContract(string movie, string customer)
        {
            var contract = new Contract()
            {
                CustomerId = customer,
                FromDate = DateTime.Now,
                ToDate = DateTime.Now.AddDays(5),
                MovieId = movie
            };
            _context.Contract.Add(contract);
            await _context.SaveChangesAsync();
            return RedirectToAction("index", "Contracts");
        }
        public IActionResult ContractInformation(string movie, string customer)
        => View("RentAMovie",new RentalViewModel
            {
                SelectedCustomer = (_context.Customer.Cast<Customer>().Where(u => u.CustomerId == customer)).Single(),
                SelectedMovie = (_context.Movie.Cast<Movie>().Where(u => u.MovieId == movie)).Single(),
                MovieList = _context.Movie.ToList() 
            });
        public IActionResult RentAMovie(string id) => View(new RentalViewModel
            {
            SelectedCustomer = (_context.Customer.Cast<Customer>().Where(u => u.CustomerId == id)).Single(),
            MovieList = _context.Movie.ToList()
            });
        public IActionResult Index() => View(_context.Customer.Join(_context.Adress, customer => customer.CustomerId,
                adress => adress.CustomerId,
                (customer, adress) => new CustomerViewModel()
                {
                    Active = customer.Active,
                    CustomerId = customer.CustomerId,
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    Street = adress.Street,
                    ZipCode = adress.ZipCode,
                    City = adress.City,
                    Country = adress.Country
                }));
        public IActionResult About() => View();     
        public IActionResult Error() => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });      
    }
}
