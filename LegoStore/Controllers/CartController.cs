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
    public class CartController : Controller
    {
        private IProductRepository productRepository;
        private IOrderRepository orderRepository;

        public CartController(IProductRepository repo, IOrderRepository order)
        {
            productRepository = repo;
            orderRepository = order;
        }

        public ViewResult Index(Cart cart, string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = cart,
                ReturnUrl = returnUrl
            }); ;
        }

        /*public Cart GetCart()
        {
            Cart cart = (Cart)Session["Cart"];
            if(cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }*/
        public RedirectToRouteResult AddToCart(Cart cart, int productId, string returnUrl)
        {
            Product product = productRepository.Products
                .FirstOrDefault(p => p.ProductId == productId);
            if(product != null)
            {
                cart.AddItem(product, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromCart(Cart cart, int productId, string returnUrl)
        {
            Product product = productRepository.Products
                .FirstOrDefault(p => p.ProductId == productId);
            if (product != null)
            {
                cart.RemoveLine(product);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);
        }

        public ViewResult Checkout()
        {
            return View(new OrderDetail());
        }

        [HttpPost]
        public ViewResult Checkout(Cart cart, OrderDetail orderDetails)
        {
            if(cart.lines.Count() == 0)
            {
                ModelState.AddModelError("", "przepraszam, koszyk jest pusty");
            }

            if(ModelState.IsValid)
            {
                orderRepository.SaveOrder(orderDetails);
                cart.Clear();
                return View("Completed");
            }

            else
            {
                return View(new OrderDetail());
            }
            
        }
    }
}