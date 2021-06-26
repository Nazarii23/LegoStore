using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Interest { get; set; }
        public string Age { get; set; }

        public int Price { get; set; }

        //public virtual ICollection<Order> Orders { get; set; }

        /*public Product()
        {
            Orders = new List<Order>();
        }*/
    }
}
