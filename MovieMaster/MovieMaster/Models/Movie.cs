using System;
using System.ComponentModel.DataAnnotations;
namespace MovieMaster.Models
{
    public class Movie
    {
        [Key]
        public string MovieId { get; set; }
        public string Titel { get; set; }
        public int AgeLimit { get; set; }
        public string Genre { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
