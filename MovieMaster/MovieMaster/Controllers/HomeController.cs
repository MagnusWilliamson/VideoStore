using System;
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
                MovieId = movie,
                ReturnDate = DateTime.MinValue
            };
            _context.Contract.Add(contract);
            await _context.SaveChangesAsync();
            return RedirectToAction("index", "Home");
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
                if (_context.Contract.Cast<Contract>().SingleOrDefault(m => (m.MovieId == mov.MovieId)&&(m.ReturnDate == DateTime.MinValue)) == null) continue;
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
                if (_context.Contract.Cast<Contract>().SingleOrDefault(m => (m.MovieId == movie.MovieId) && (m.ReturnDate == DateTime.MinValue)) == null) continue;
                model.MovieList.Remove(movie);
            }
            return View(model);
        }
        public IActionResult Index() =>
            View((_context.Customer.Join(
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
                    Country = adress.Country,
                    Contract = (_context.Contract.SingleOrDefault(c => (c.CustomerId == customer.CustomerId) && (c.ReturnDate == DateTime.MinValue)) != null)
                })));
        public IActionResult About() => View();     
        public IActionResult Error() => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });

        public IActionResult FirstNameSort() =>
                    View("index", from customer in (_context.Customer.Join(
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
                        Country = adress.Country,
                        Contract = (_context.Contract.SingleOrDefault(c =>
                        (c.CustomerId == customer.CustomerId) 
                        && (c.ReturnDate == DateTime.MinValue)) !=null)
                    }))
                orderby customer.FirstName
                select customer);
        public IActionResult LastNameSort() =>
            View("index", from customer in (_context.Customer.Join(
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
                        Country = adress.Country,
                        Contract = (_context.Contract.SingleOrDefault(c =>
                                        (c.CustomerId == customer.CustomerId)
                                        && (c.ReturnDate == DateTime.MinValue)) != null)
                    }))
                orderby customer.LastName
                select customer);
        public IActionResult StreetSort() =>
            View("index", from customer in (_context.Customer.Join(
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
                        Country = adress.Country,
                        Contract = (_context.Contract.SingleOrDefault(c =>
                                        (c.CustomerId == customer.CustomerId)
                                        && (c.ReturnDate == DateTime.MinValue)) != null)
                    }))
                orderby customer.Street
                select customer);
        public IActionResult ZipcodeSort() =>
            View("index", from customer in (_context.Customer.Join(
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
                        Country = adress.Country,
                        Contract = (_context.Contract.SingleOrDefault(c =>
                                        (c.CustomerId == customer.CustomerId)
                                        && (c.ReturnDate == DateTime.MinValue)) != null)
                    }))
                orderby customer.ZipCode
                select customer);
        public IActionResult CitySort() =>
            View("index", from customer in (_context.Customer.Join(
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
                        Country = adress.Country,
                        Contract = (_context.Contract.SingleOrDefault(c =>
                                        (c.CustomerId == customer.CustomerId)
                                        && (c.ReturnDate == DateTime.MinValue)) != null)
                    }))
                orderby customer.City
                select customer);
        public IActionResult CountrySort() =>
            View("index", from customer in (_context.Customer.Join(
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
                        Country = adress.Country,
                        Contract = (_context.Contract.SingleOrDefault(c =>
                                        (c.CustomerId == customer.CustomerId)
                                        && (c.ReturnDate == DateTime.MinValue)) != null)
                    }))
                orderby customer.Country
                select customer);
    }
}
