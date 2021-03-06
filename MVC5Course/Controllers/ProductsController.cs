﻿namespace MVC5Course.Controllers
{
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;

    using MVC5Course.ActionFilters;
    using MVC5Course.Models;
    using MVC5Course.ViewModels;

    using PagedList;
    using PagedList.Mvc;

    public class ProductsController : Controller
    {
        private readonly FabricsEntities db = new FabricsEntities();

        // GET: Products/Create
        [提供產品價格下拉式選單資料Attrbiute]
        public ActionResult Create()
        {
            return this.View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductId,ProductName,Price,Active,Stock")] Product product)
        {
            if (this.ModelState.IsValid)
            {
                this.db.Product.Add(product);
                this.db.SaveChanges();
                return this.RedirectToAction("Index");
            }

            return this.View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var product = this.db.Product.Find(id);
            if (product == null) return this.HttpNotFound();
            return this.View(product);
        }

        // POST: Products/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var product = this.db.Product.Find(id);
            this.db.Product.Remove(product);
            this.db.SaveChanges();
            return this.RedirectToAction("Index");
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var product = this.db.Product.Find(id);
            if (product == null) return this.HttpNotFound();

            ViewBag.OrderLines = product.OrderLine.ToList();

            return this.View(product);
        }

        // GET: Products/Edit/5
        [提供產品價格下拉式選單資料Attrbiute]
        public ActionResult Edit(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var product = this.db.Product.Find(id);
            if (product == null) return this.HttpNotFound();

            return this.View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id)
        {
            var product = db.Product.Find(id);

            if (TryUpdateModel(product, new string[] { "ProductId", "Price", "Active", "Stock" }))
            {
                this.db.SaveChanges();
                return this.RedirectToAction("Index");
            }

            return this.View(product);
        }

        // GET: Products
        public ActionResult Index(int pageNumber = 1)
        {
            var data = db.Product.OrderBy(p => p.ProductId)
                .ToPagedList(pageNumber, 10);

            return this.View(data);
        }

        public ActionResult List()
        {
            var data = (from p in db.Product
                       select new ProductListVM
                       {
                           ProductId = p.ProductId,
                           ProductName = p.ProductName,
                           Price = p.Price,
                           Stock = p.Stock
                       }).Take(10);

            return View(data);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) this.db.Dispose();
            base.Dispose(disposing);
        }
    }
}