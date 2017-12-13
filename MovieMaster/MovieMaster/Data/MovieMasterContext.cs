using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MovieMaster.Models;

namespace MovieMaster.Models
{
    public class MovieMasterContext : DbContext
    {
        public MovieMasterContext (DbContextOptions<MovieMasterContext> options)
            : base(options)
        {
        }

        public DbSet<MovieMaster.Models.Customer> Customer { get; set; }

        public DbSet<MovieMaster.Models.Movie> Movie { get; set; }

        public DbSet<MovieMaster.Models.Adress> Adress { get; set; }

        public DbSet<MovieMaster.Models.Contract> Contract { get; set; }
    }
}
