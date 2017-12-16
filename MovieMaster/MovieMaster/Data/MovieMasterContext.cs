using Microsoft.EntityFrameworkCore;

namespace MovieMaster.Data
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
