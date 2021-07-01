using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class OrderDetail
    {
        [Key]
        public int OrderId { get; set; }

        [Required(ErrorMessage = "Prosze podać imię")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Prosze podać adress")]
        
        public string OrderAdress { get; set; }
        [Required(ErrorMessage = "Prosze podać email")]
        
        public string OrderEmail { get; set; }
        [Required(ErrorMessage = "Prosze podać miasto")]
        
        public string OrderCity { get; set; }
        [Required(ErrorMessage = "Prosze podać kraj")]
        
        public string OrderCountry { get; set; }
        public DateTime? OrderDate { get; set; }
        public bool GiftWrap { get; set; }

        //public ICollection<Product> Products { get; set; }

        /*public OrderDetail()
        {
            Products = new List<Product>();
        }*/
    }
}
