using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcProject.Models;
using MvcProject.Services;
using System.Collections.Generic;
using System.Linq;

namespace MvcProject.Controllers
{
    [Authorize(Roles = "admin")]
    public class ResturantController : Controller
    {

        RestRepository rRepository;
        public ResturantController()
        {
            rRepository = new RestRepository();
        }


        public IActionResult Index()
        {
            Restaurant Rest = rRepository.GetRest(); 
            return View(Rest);
        }
        public IActionResult EditItem(int id)
        {
            Restaurant Rest = rRepository.GetRest(); 
            Item itm = Rest.Items.FirstOrDefault(i => i.Id == id);
            return View(itm);
        }
        public IActionResult SaveEditItem(int id, Item itm)
        {
            if (itm.Price != 0)
            {
                rRepository.update(id,itm);
               
                return RedirectToAction("Index");
            }
            return View("EditItem", itm);
        }
        
        public IActionResult DeleteItem(int id)
        {
                rRepository.delete(id);
                
                return RedirectToAction("Index");
        }

        public IActionResult AddItem()
        {
            return View(new Item());
        }
        public IActionResult SaveItem(Item itm)
        {
            if (itm.Price != 0)
            {
                rRepository.insert(itm);
               
                return RedirectToAction("Index");
            }
            else
            {
                return View("AddItem", itm);
            }
        }
        [AllowAnonymous]
        public IActionResult orderList()
        {
            List<Order> orders = rRepository.GetOrdersList(); 
            List<Item> items = new List<Item>();
            return View(orders);
        }
  
        [AllowAnonymous]
        public IActionResult RemoveOrder(int id)
        {
            rRepository.RemoveOrder(id);
           
            return RedirectToAction("orderList");
        }

    }
}
