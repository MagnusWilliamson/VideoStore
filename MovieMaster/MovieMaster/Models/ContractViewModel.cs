using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MovieMaster.Models
{
    [NotMapped]
    public class ContractViewModel: Contract
    {
        [Display(Name = "Customer")]
        public string CustomerName { get; set; }
    }
}
