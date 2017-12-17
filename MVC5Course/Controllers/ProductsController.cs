namespace MVC5Course.Controllers
{
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;

    using MVC5Course.Models;
    using MVC5Course.ViewModels;

    public class ProductsController : Controller
    {
        private readonly FabricsEntities db = new FabricsEntities();

        // GET: Products/Create
        public ActionResult Create()
        {
            /*
            var prices = new List<SelectListItem>
            {
                new SelectListItem { Text = "$30", Value = "30" },
                new SelectListItem { Text = "$40", Value = "40" },
                new SelectListItem { Text = "$50", Value = "50" }
            };
            */

            var prices = (from p in db.Product
                          select new
                          {
                              Text = p.Price,
                              Value = p.Price
                          })
                          .Distinct()
                          .OrderBy(p => p.Value);

            ViewBag.Price = new SelectList(prices, "Value", "Text");

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
        public ActionResult Edit(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var product = this.db.Product.Find(id);
            if (product == null) return this.HttpNotFound();

            var prices = db.Product
                .AsEnumerable()
                .Select(p => new
                {
                    Text = string.Format("{0:c}", p.Price),
                    Value = p.Price
                })
                .Distinct()
                .OrderBy(p => p.Value);

            ViewBag.Price = new SelectList(prices, "Value", "Text");
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
        public ActionResult Index()
        {
            return this.View(this.db.Product.Take(10));
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