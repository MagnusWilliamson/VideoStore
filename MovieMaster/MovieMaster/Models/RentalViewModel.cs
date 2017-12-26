using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieMaster.Models
{
    [NotMapped]
    public class RentalViewModel
    {
        [Required]
        public Customer SelectedCustomer;
        [Required]
        public Movie SelectedMovie;
        public ICollection<Movie> MovieList { get; set; }
    }
}
