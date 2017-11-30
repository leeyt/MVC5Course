namespace MVC5Course.Controllers
{
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;

    using MVC5Course.Models;

    public class ProductsController : Controller
    {
        private readonly FabricsEntities db = new FabricsEntities();

        // GET: Products/Create
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
            return this.View(product);
        }

        // GET: Products/Edit/5
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
        public ActionResult Edit([Bind(Include = "ProductId,ProductName,Price,Active,Stock")] Product product)
        {
            if (this.ModelState.IsValid)
            {
                this.db.Entry(product).State = EntityState.Modified;
                this.db.SaveChanges();
                return this.RedirectToAction("Index");
            }

            return this.View(product);
        }

        // GET: Products
        public ActionResult Index()
        {
            return this.View(this.db.Product.ToList());
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) this.db.Dispose();
            base.Dispose(disposing);
        }
    }
}