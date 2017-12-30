using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieMaster.Data;
using MovieMaster.Models;

namespace MovieMaster.Controllers
{
    public class HomeController : Controller
    {
        private readonly MovieMasterContext _context;
        public HomeController(MovieMasterContext context) =>_context = context;
        public async Task<IActionResult> CreateContract(string movie, string customer)
        {
            var contract = new Contract
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
        {
            var model = new RentalViewModel
            {
                SelectedCustomer = (_context.Customer.Cast<Customer>().Where(u => u.CustomerId == customer)).Single(),
                SelectedMovie = (_context.Movie.Cast<Movie>().Where(u => u.MovieId == movie)).Single(),
                MovieList = _context.Movie.ToList()
            };

            foreach (var mov in _context.Movie)
            {
                if (_context.Contract.Cast<Contract>().SingleOrDefault(m => (m.MovieId == mov.MovieId)&&(m.ReturnDate > DateTime.Now)) == null) continue;
                model.MovieList.Remove(mov);
            }
            return View("RentAMovie", model);
        }

        public IActionResult RentAMovie(string id)
        {         
            var model = new RentalViewModel
            {
                SelectedCustomer = (_context.Customer.Cast<Customer>().Where(u => u.CustomerId == id)).Single(),
                MovieList = _context.Movie.ToList()
            };
            foreach (var movie in _context.Movie)
            {
                if (_context.Contract.Cast<Contract>().SingleOrDefault(m => (m.MovieId == movie.MovieId) && (m.ReturnDate > DateTime.Now)) == null) continue;
                model.MovieList.Remove(movie);
            }
            return View(model);
        }

        public IActionResult Index() => View(_context.Customer.Join(
                _context.Adress, customer => customer.CustomerId,
                adress => adress.CustomerId,
                (customer, adress) => new CustomerViewModel
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
