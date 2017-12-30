using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace MovieMaster.Models
{
    [NotMapped]
    public class CustomerViewModel: Customer
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public bool Contract { get; set; }
    }
}
