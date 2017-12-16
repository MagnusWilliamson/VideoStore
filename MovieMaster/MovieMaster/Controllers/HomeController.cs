using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MovieMaster.Models;
using MovieMaster.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Internal;


namespace MovieMaster.Controllers
{
    public class HomeController : Controller
    {
        private readonly MovieMasterContext _context;

        public HomeController(MovieMasterContext context)
        {
            _context = context;
        }

        public IActionResult Index() => View(_context.Customer.Join(_context.Adress, customer => customer.CustomerId,
                adress => adress.CustomerId,
                (customer, adress) => new CustomerAdress()
                {
                    Active = customer.Active,
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
