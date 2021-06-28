using Domain.Abstract;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LegoStore.Controllers
{
    public class AdminController : Controller
    {


        IProductRepository productRepository;

        public AdminController(IProductRepository repo)
        {
            productRepository = repo;
        }
        
        public ActionResult Index()
        {
            
            return View(productRepository.Products);
        }

        public ActionResult Edit(int productID)
        {
            Product product = productRepository.Products.FirstOrDefault(p => p.ProductId == productID);

            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                productRepository.SaveProduct(product);

                TempData["message"] = string.Format("Product \"{0}\" are successful changed", product.Name);
                return RedirectToAction("Index");
            }
            else
            {
                return View(product);
            }
        }

        public ActionResult CreateProduct()
        {
            return View(new Product());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                productRepository.SaveProduct(product);
                TempData["message"] = string.Format("Product \"{0}\" are successful created", product.Name);
            }
            else
            {
                return View(product);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult DeleteProduct(int productID)
        {
            if (ModelState.IsValid)
            {
                Product product = productRepository.Products.FirstOrDefault(p => p.ProductId == productID);
                productRepository.DeleteProduct(product);
                TempData["message"] = string.Format("Product \"{0}\" are successful deleted", product.Name);
            }

            return RedirectToAction("Index");
        }
    }
}