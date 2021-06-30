using Domain.Abstract;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LegoStore.Controllers
{
    public class CartController : Controller
    {
        private IProductRepository productRepository;
        public CartController(IProductRepository repo)
        {
            productRepository = repo;
        }

        public Cart GetCart()
        {
            Cart cart = (Cart)Session["Cart"];
            if(cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }
        public RedirectToRouteResult AddToCart(int productId, string returnUrl)
        {
            Product product = productRepository.Products
                .FirstOrDefault(p => p.ProductId == productId);
            if(product != null)
            {
                GetCart().AddItem(product, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromCart(int productId, string returnUrl)
        {
            Product product = productRepository.Products
                .FirstOrDefault(p => p.ProductId == productId);
            if (product != null)
            {
                GetCart().RemoveLine(product);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
    }
}