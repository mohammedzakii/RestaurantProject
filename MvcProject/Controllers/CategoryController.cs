using Microsoft.AspNetCore.Mvc;
using MvcProject.Models;
using System.Collections.Generic;
using System.Linq;

namespace MvcProject.Controllers
{
    public class CategoryController : Controller
    {
        RestDB db = new RestDB();
        public IActionResult Index()
        {
            List<Category> cat = db.Categories.ToList();
            ViewData["cat"] = cat;
            return View();
        }
    }
}
