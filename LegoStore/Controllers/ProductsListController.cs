using Domain.Abstract;
using LegoStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LegoStore.Controllers
{
    public class ProductsListController : Controller
    {
        // GET: ProductsList
        private IProductRepository productRepository;
        public int pageSize = 4;

        public ProductsListController(IProductRepository repo)
        {
            productRepository = repo;
        }

        public ViewResult List(int productpage = 1)
        {
            ProductListViewModel model = new ProductListViewModel
            {
                Products = productRepository.Products
                       .OrderBy(Products => Products.ProductId)
                       .Skip((productpage - 1) * pageSize)
                       .Take(pageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = productpage,
                    ItemsPerPage = pageSize,
                    TotalItems = productRepository.Products.Count()
                }
            };
            return View(model);
        }
    }
}