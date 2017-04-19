using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using autotune.Models;

namespace autotune.Controllers
{
    public class HomeController : Controller
    {
        ProjectRepository repo = new ProjectRepository();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Categories()
        {
            return View();
        }

        public ActionResult Category(string categoryName)
        {
            IEnumerable<Product> products = repo.Products.Where(p => p.Category.ToString() == categoryName);
            return View(products.ToList());
        }

        public ActionResult Contacts()
        {
            return View();
        }
    }
}