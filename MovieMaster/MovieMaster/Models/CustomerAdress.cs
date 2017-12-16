﻿using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace MovieMaster.Models
{
    [NotMapped]
    public class CustomerAdress: Customer
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
    }
}
