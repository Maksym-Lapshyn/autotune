using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using autotune.Models;

namespace autotune.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        ProjectRepository repo = new ProjectRepository();

        public ActionResult Index()
        {
            return View(repo.Products);
        }

        public ActionResult EditProduct(int id)
        {
            Product product = repo.Products.FirstOrDefault(p => p.Id == id);
            return View(product);
        }

        [HttpPost]
        public ActionResult EditProduct(Product product, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                repo.SaveProduct(product);
                if (image != null)
                {
                    string imageName = string.Format("big_{0}.jpg", product.Id);
                    image.SaveAs(Server.MapPath("~/Images/" + imageName));
                    product.BigImage = imageName;
                    repo.SaveProduct(product);
                }
                TempData["success"] = string.Format("Товар {0} сохранен", product.Name);
                return RedirectToAction("Index");
            }
            else
            {
                return View(product);
            }
        }

        [HttpPost]
        public ActionResult DeleteProduct(int id)
        {
            Product productForDelete = repo.DeleteProduct(id);
            if (productForDelete != null)
            {
                TempData["message"] = string.Format("Товар {0} удален", productForDelete.Name);
            }
            return RedirectToAction("Index");
        }

        public ActionResult CreateProduct()
        {
            ViewBag.New = true;
            return View("EditProduct", new Product());
        }
    }
}