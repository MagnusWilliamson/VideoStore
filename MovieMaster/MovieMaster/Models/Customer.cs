using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieMaster.Models
{
    public class Customer
    {
        public string CustomerId { get; protected set; }
        public bool Active { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
