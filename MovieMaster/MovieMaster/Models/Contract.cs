using System;
using System.Collections.Generic;

namespace MovieMaster.Models
{
    public class Contract
    {
        public string ContractId { get; set; }
        public string CustomerId { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public ICollection<Movie> MovieId { get; set; }
    }
}
