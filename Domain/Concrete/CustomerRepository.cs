using Domain.Abstract;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Domain.Concrete
{
    public class CustomerRepository : ICustomerRepository
    {
        private LegoStoreContext context = GeneralContext.context;
        public IEnumerable<Customer> Customers
        {
            get { return context.Customers; }
        }

        public void SaveCustomer(Customer customer)
        {
            
            if (customer.CustomerId == 0)
            {
                context.Customers.Add(customer);
            }
            else
            {
                Customer dbCustomer = context.Customers.Find(customer.CustomerId);
                
                if (dbCustomer != null)
                {
                    dbCustomer.Email = customer.Email;
                    dbCustomer.Password = customer.Password;
                    dbCustomer.FirstName = customer.FirstName;
                    dbCustomer.LastName = customer.LastName;
                    dbCustomer.Phone = customer.Phone;
                    //dbCustomer.Orders = customer.Orders;
                }

                

            }
            context.SaveChanges();
        }

        /*public void LoginCustomer(Customer customer)
        {
            Customer dbCustomer = context.Customers.Find(customer.CustomerId);

            if (dbCustomer != null)
            {
                dbCustomer.Email = customer.Email;
                dbCustomer.Password = customer.Password;
                //dbCustomer.Orders = customer.Orders;
            }
 
        }*/
        /*
        public void LoginCustomer(Customer customer)
        {
            if (customer.CustomerId != 0)
            {
                context.Customers.Find(customer.CustomerId);
            }
            else 
            {
                Customer dbCustomer = context.Customers.Find(customer.CustomerId);
                if (dbCustomer != null)
                {
                    context.Customers.FirstOrDefault(cus => cus.Email == customer.Email && cus.Password == customer.Password);
                }
                context.Customers.FirstOrDefault(cus => cus.Email == customer.Email && cus.Password == customer.Password);
            }
        }*/

        public void DeleteCustomer(Customer customer)
        {
            if (customer.CustomerId != 0)
            {
                Customer dbCustomer = context.Customers.Find(customer.CustomerId);

                if (dbCustomer != null)
                {
                    context.Customers.Remove(dbCustomer);
                    context.SaveChanges();
                }
            }
        }
    }
}
