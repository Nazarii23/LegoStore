using Domain.Abstract;
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
        public int pageSize = 4;

        public HomeController(IProductRepository repo)
        {
            productRepository = repo;
        }


        public ActionResult Index(int productPage = 1)
        {
            ViewBag.productPage = productPage;
            return View();
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
    }
}