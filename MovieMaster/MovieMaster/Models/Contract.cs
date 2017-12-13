using System;

namespace MovieMaster.Models
{
    public class Contract
    {
        public string ContractId { get; set; }
        public string CustomerId { get; set; }
        public string MovieId { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public bool Returned { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
