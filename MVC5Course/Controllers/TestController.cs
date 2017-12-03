namespace MVC5Course.Controllers
{
    using System.Data.Entity;
    using System.Linq;
    using System.Web.Mvc;

    using MVC5Course.Models;

    public class TestController : Controller
    {
        IProductRepository repo = RepositoryHelper.GetProductRepository();

        // GET: Test
        public ActionResult Index()
        {
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
                repo.Add(data);
                repo.UnitOfWork.Commit();

                return RedirectToAction("Index");
            }

            return View(data);
        }

        public ActionResult Edit(int id)
        {
            var item = repo.Find(id);

            return View(item);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Product data)
        {
            if (ModelState.IsValid)
            {
                var item = repo.Find(id);

                item.ProductName = data.ProductName;
                item.Price = data.Price;
                item.Stock = data.Stock;

                repo.UnitOfWork.Commit();
                
                return RedirectToAction("Index");
            }

            return View(data);
        }

        public ActionResult Details(int id)
        {
            return View(repo.Find(id));
        }

        public ActionResult Delete(int id)
        {
            var product = repo.Find(id);

            product.IsDeleted = true;

            repo.UnitOfWork.Commit();

            return RedirectToAction("Index");
        }

    }
}