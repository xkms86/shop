
using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public void Index()
        {
            


        }


        [ActionName("Pokaz")]
        public ActionResult Display(int id)
        {
            Product product = new Product();
            product.Id = 1;
            product.Name = "Przełącznik ON-OFF";
            product.Description = "Przełącznik samochodowy, czarny";
            product.Price = 3;

            if (product.Id == id)
                return View("~/Views/Product/Display.cshtml", product);
            else
                return RedirectToAction("Index", "Home");
                    }
    }
}