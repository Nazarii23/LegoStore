using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Domain.Entities
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public int Age { get; set; }

        public int RoleId { get; set; }
        public Role Role { get; set; }
        


        //public virtual ICollection<OrderDetails> Orders { get; set; }

        /*public Customer()
        {
            Orders = new List<OrderDetails>();
        }*/
    }
    public class Role
    {
       [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
