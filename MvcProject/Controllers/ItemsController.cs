using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcProject.Models;
using MvcProject.Services;

namespace MvcProject.Controllers
{
    [Route("items")]

    public class ItemsController : Controller
    {

        ItemsRepository obj;
        public ItemsController()
        {
            obj = new ItemsRepository();
        }
        [Route("index")]

        public IActionResult index()
        {
            ViewBag.Items = obj.getAll();
            return View();
        }
        [Route("Itemgetallcard")]
        [HttpGet]
        public IActionResult Itemgetallcard(int catid)

        {
            List<Item> itemModel = obj.Itemgetallcard(catid); // db.Items.Where(d => d.cat_id == catid).Include(d => d.Category).ToList();
            return PartialView("_itemcard", itemModel);


        }

        
    }
}











































