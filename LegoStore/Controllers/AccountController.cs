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
        public ActionResult Login()
        {
            return View();
        }

        //IProductRepository productRepository;
        ICustomerRepository customerRepository;
        //public AccountController(IProductRepository repo, ICustomerRepository cust)
        public AccountController(ICustomerRepository cust)
        {
            //productRepository = repo;
            customerRepository = cust;
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                Customer user = null;
                user = customerRepository.Customers.FirstOrDefault(u => u.Email == model.Email && u.Password == model.Password);

                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(model.Email, true);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError(" ", "Niema takiego logina");
                }
            }
            return View(model);
        }


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
                customerRepository.SaveCustomer(customer);
                TempData["message"] = string.Format("Product \"{0}\" are successful created", customer.Email);
            }
            else
            {
                return View(customer);
            }

            return RedirectToAction("Index","Home");
        }

    }
}