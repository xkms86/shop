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
        static List<Product> _products = new List<Product> {
            new Product {Id=1, Name = "Myszka", Description="Kożystaj z okazji i KUP mYSZKE!!!", Price = 500},
            new Product {Id=2, Name = "Klawiatura", Description="Opis klawiatury", Price = 300},
            new Product {Id=3, Name = "Laser", Description="Opis lasera", Price = 100},
            new Product {Id=4, Name = "Gumka", Description="Opis gumki", Price = 50}
        };

         // GET: Product
         public ActionResult Index()
        {
                        
           var model = _products;
           return View(model);
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            var model = _products.FirstOrDefault(p => p.Id == id);
            
            if (model == null)
            return RedirectToAction("Index");

            return View(model);
           
        }

        [ChildActionOnly]
        public ActionResult CheapestProduct()
        {
            var model = _products.FirstOrDefault(p => p.Price == _products.Min(pr => pr.Price));
            return PartialView("_Product", model);
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(Product collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            var product = _products.Single(p => p.Id == id);
            return View(product);
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Product collection)
        {
            var product = _products.Single(p => p.Id == id);
            if(TryUpdateModel(product))
            {
                return RedirectToAction("Index");
            }
                
            
                return View(product);
            
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Product collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
