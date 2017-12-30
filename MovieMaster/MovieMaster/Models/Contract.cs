using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace MovieMaster.Models
{
    public class Contract
    {
        [Key]
        public string ContractId { get; set; }
        public string CustomerId { get; set; }
        [DataType(DataType.Date)]
        public DateTime FromDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime ToDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime ReturnDate { get; set; }
        public string MovieId { get; set; }
    }
}
