using Domain.Abstract;
using Domain.Entities;
using LegoStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace LegoStore.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        
        ICustomerRepository customerRepository;
        
        public AccountController(ICustomerRepository cust)
        {
            
            customerRepository = cust;
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Customer customer)
        {
            if (ModelState.IsValid)
            {
                
                customer = customerRepository.Customers.FirstOrDefault(cus => cus.Email == customer.Email && cus.Password == customer.Password);
                
                //Customer customer = customerRepository.Customers.FirstOrDefault(p => p.CustomerId == CustomerId);
                //customerRepository.SaveCustomer(customer);
                //TempData["message"] = string.Format("Product \"{0}\" are successful created", customer.Email);

                if (customer != null)
                {
                    FormsAuthentication.SetAuthCookie(customer.Email, true);
                }
                else
                {
                    ModelState.AddModelError("", "user with this username or password was not found");
                    return View(customer);
                }
            }
            
            

            return RedirectToAction("Index", "Home");
        }
        /* public ActionResult Login(Customer customer)
         {
             if(ModelState.IsValid)
             {
                 customerRepository.LoginCustomer(customer);
                 TempData["message"] = string.Format("Product \"{0}\" are successful created", customer.Email);
             }

             else
             {
                 return View(customer);
             }

             return RedirectToAction("Index", "Home");

         }*/
        public ActionResult Register()
        {
            return View(new Customer());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Customer customer)
        {
            if (ModelState.IsValid)
            {
                //customer = customerRepository.Customers.FirstOrDefault(x => x.CustomerId == customer.CustomerId);
                customer.RoleId = 2;
                customerRepository.SaveCustomer(customer);
                
                TempData["message"] = string.Format("Product \"{0}\" are successful created", customer.Email);
                if (customer != null)
                {
                    FormsAuthentication.SetAuthCookie(customer.Email, true);
                }

                else
                {
                    ModelState.AddModelError("", "the user is already registered");
                    return View(customer);
                }
            }
            
            return RedirectToAction("Index","Home");
        }

    }
}