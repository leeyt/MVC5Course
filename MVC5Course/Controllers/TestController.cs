namespace MVC5Course.Controllers
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
            var data = from p in db.Product
                       select p;

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

            db.OrderLine.RemoveRange(product.OrderLine.ToList());

            db.Product.Remove(product);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}