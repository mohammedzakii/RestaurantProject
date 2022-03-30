using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using MvcProject.Helpers;
using MvcProject.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace MvcProject.Controllers
{[Authorize]
    [Route("cart")]
    public class CartController : Controller
    {
        RestDB db = new RestDB();

        [Route("index")]

        public IActionResult Index()
        {
            var cart = SessionHelper.GetObjectFromJson<List<Product>>(HttpContext.Session, "cart");

            ViewBag.Cart = cart;
            ViewBag.total = cart.Sum(i => i.item.Price * i.Quantity);

            return View();

        }
        [Route("checkout")]
        public IActionResult checkout()
        {
            var cart = SessionHelper.GetObjectFromJson<List<Product>>(HttpContext.Session, "cart");
            //ViewBag.Cart = cart;          
            //ViewBag.total = cart.Sum(i => i.item.Price * i.Quantity);
            int totSum = 0;
            Order order = new Order();
            order.Price = totSum;
            db.Orders.Add(order);
            db.SaveChanges();

            List<ItemOrder> ItemOrders = new List<ItemOrder>();
            int i = 0;

            foreach (var item in cart)
            {
                ItemOrders.Add(new ItemOrder());
                ItemOrders[i].Item_Id = item.item.Id;
                ItemOrders[i].Order_Id = order.Id;
                totSum += (int)(cart.Sum(i => i.item.Price * i.Quantity));
                db.ItemOrders.Add(ItemOrders[i]);
                db.SaveChanges();
                i++;
            }
            order.Price = totSum;
            db.SaveChanges();
            //order.Status = "pending";
            db.SaveChanges();
            //ViewData["ordID"] = order.Id;
            return RedirectToAction("done");
        }
        public IActionResult done()
        {
            //int odrId=ViewBag.odrId;
            //Order order = db.Orders.Include(i => i.ItemOrder).ThenInclude(s=>s.Item).FirstOrDefault(i=>i.Id== odrId);
            return View();
        }

        [Route("buy/{id}")]

        public IActionResult buy(int id)
        {
            if (SessionHelper.GetObjectFromJson<List<Product>>(HttpContext.Session, "cart") == null)
            {

                var cart = new List<Product>();
                cart.Add(new Product() { item = db.Items.Find(id), Quantity = 1 });
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);

                // ViewData["cart"] = cart;


            }
            else
            {
                var cart = SessionHelper.GetObjectFromJson<List<Product>>(HttpContext.Session, "cart");
                int index = Exists(cart, id);
                if (index == -1)
                {
                    cart.Add(new Product() { item = db.Items.Find(id), Quantity = 1 });


                }
                else
                {
                    cart[index].Quantity++;
                }
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
                //ViewData["cart"] = cart;



            }

            return RedirectToAction("Index");

        }
        [Route("remove/{id}")]
        public IActionResult Remove(int id)
        {
            var cart = SessionHelper.GetObjectFromJson<List<Product>>(HttpContext.Session, "cart");
            int index = Exists(cart, id);
            cart.RemoveAt(index);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return RedirectToAction("Index");
        }

        private int Exists(List<Product> cart, int id)
        {
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].item.Id == id)
                {
                    return i;
                }

            }
            return -1;
        }
    }
    
}
