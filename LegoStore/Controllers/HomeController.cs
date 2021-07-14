using Domain.Abstract;
using Domain.Entities;
using LegoStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LegoStore.Controllers
{
    public class HomeController : Controller
    {
        private IProductRepository productRepository;
        ICustomerRepository customerRepository;
        public int pageSize = 4;

        public HomeController(IProductRepository repo, ICustomerRepository cust)
        {
            productRepository = repo;
            customerRepository = cust;
        }


        public ActionResult Index(int productPage = 1)
        {
            
            ViewBag.productPage = productPage;
            return View();
        }

        public PartialViewResult AccountR(Customer customer)
        {
            return PartialView(customer);
        }
        

        public PartialViewResult ProductsRow(int page = 1)
        {
            ProductListViewModel model = new ProductListViewModel
            {
                Products = productRepository.Products
                       .OrderBy(Products => Products.ProductId)
                       .Skip((page - 1) * pageSize)
                       .Take(pageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = productRepository.Products.Count()
                }
            };

            return PartialView(model);
        }

        
        /*public ActionResult About()
        {
            ViewBag.Message = "vgvrfgb rgvregregreg";
            return View();
        }*/
    }
}