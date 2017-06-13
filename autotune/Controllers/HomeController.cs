using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using autotune.Models;
using autotune.Infrastructure;

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

        public ActionResult Product(int productId)
        {
            Product product = repo.Products.Where(p => p.Id == productId).FirstOrDefault();
            return View(product);
        }

        public PartialViewResult SimilarProducts(int productId)
        {
            Product product = repo.Products.Where(p => p.Id == productId).First();
            List<Product> products = repo.Products.Where(p => p.Category == product.Category).Shuffle(new Random()).ToList();
            return PartialView(products);
        }

        public ActionResult Contacts()
        {
            return View();
        }
    }
}