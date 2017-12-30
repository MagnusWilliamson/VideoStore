using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace MovieMaster.Models
{
    [NotMapped]
    public class CustomerAdressViewModel
    {
        public Customer Customer { get; set; }
        public Adress Adress { get; set; }
    }
}
