﻿namespace MVC5Course.Controllers
{
    using System.Data.Entity;
    using System.Linq;
    using System.Web.Mvc;

    using MVC5Course.Models;

    public class TestController : Controller
    {
        private readonly FabricsEntities db = new FabricsEntities();

        // GET: Test
        public ActionResult Index()
        {
            var repo = new ProductRepository();
            repo.UnitOfWork = new EFUnitOfWork();
            var data = repo.All().Where(p => !p.IsDeleted);

            return View(data.Take(10));
        }

        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(Product data)
        {
            if (ModelState.IsValid)
            {
                db.Product.Add(data);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(data);
        }

        public ActionResult Edit(int id)
        {
            var item = db.Product.Find(id);

            return View(item);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Product data)
        {
            if (ModelState.IsValid)
            {
                var item = db.Product.Find(id);

                item.ProductName = data.ProductName;
                item.Price = data.Price;
                item.Stock = data.Stock;

                db.SaveChanges();
                
                return RedirectToAction("Index");
            }

            return View(data);
        }

        public ActionResult Details()
        {
            return View(db.Product.Take(10));
        }

        public ActionResult Delete(int id)
        {
            var product = db.Product.Find(id);

            product.IsDeleted = true;

            db.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}