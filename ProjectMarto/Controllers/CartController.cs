using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectMarto.ActionFilters;
using ProjectMarto.ExtentionMethods;
using ProjectMarto.Models;
using ProjectMarto.Repositories;
using ProjectMarto.ViewModels.Cart;
using System.Collections.Generic;

namespace ProjectMarto.Controllers
{
    [AuthenticationFilter]
    public class CartController : Controller
    {
        private const string CartSessionKey = "Cart";

        // Add an item to the cart
        public IActionResult AddToCart(int id)
        {
            OnlineShopDbContext context = new OnlineShopDbContext();
            List<Product> cart = this.HttpContext.Session.GetObject<List<Product>>(CartSessionKey) ?? new List<Product>();

            Product product = context.Products.FirstOrDefault(p => p.ProductId == id);
            
            if (product != null)
            {
                if (cart.FirstOrDefault(p => p.ProductId == product.ProductId) != null)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    cart.Add(product);
                    HttpContext.Session.SetObject(CartSessionKey, cart);
                    
                }
           
            }
            return RedirectToAction("Index", "Cart");


        }

        // View the cart
        public IActionResult Index()
        {
            IndexVM model = new IndexVM();  
            model.Products =this.HttpContext.Session.GetObject<List<Product>>(CartSessionKey) ?? new List<Product>();
            return View(model);
        }

        // Remove an item from the cart
        public IActionResult RemoveFromCart(int id)
        {
            List<Product> cart = HttpContext.Session.GetObject<List<Product>>(CartSessionKey) ?? new List<Product>();

            Product item = cart.FirstOrDefault(c => c.ProductId == id);
            if (item != null)
            {
                cart.Remove(item);
            }

            HttpContext.Session.SetObject(CartSessionKey, cart);
            return RedirectToAction("Index","Cart");
        }

        public IActionResult Buy()
        {
            OnlineShopDbContext context = new OnlineShopDbContext();
            List<Product> cart = HttpContext.Session.GetObject<List<Product>>(CartSessionKey) ?? new List<Product>();
            User user = this.HttpContext.Session.GetObject<User>("loggedUser");

            if (cart.Count > 0&& user!=null)
            {
                Order order = new Order();
                order.UserId = user.UserId;
                order.OrderDate= DateTime.Now;
                order.TotalPrice = 0;
                
                context.Orders.Add(order);
                context.SaveChanges();
            
                foreach(Product product in cart)
                {
                    order.TotalPrice += product.Price;

                    OrderProduct orderProduct = new OrderProduct(); 
                    orderProduct.ProductId = product.ProductId;
                    orderProduct.OrderId = order.OrderId;

                    //order.OrderProducts.Add(orderProduct);
                    context.OrderProducts.Add(orderProduct);
                }

                context.Entry(order).State = EntityState.Modified;
                context.SaveChanges();
            }


            this.HttpContext.Session.SetObject<List<Product>>(CartSessionKey, null);
            return RedirectToAction("Index", "Cart");
        }
    }
}
