namespace MVC5Course.Controllers
{
    using System.Web.Mvc;

    using MVC5Course.Models;

    public class TestController : BaseController
    {
        // GET: Test
        public ActionResult Index()
        {
            var data = repo.Get取得所有尚未刪除的商品資料Top10();

            return View(data);
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

                TempData["ProductItem"] = data;

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
            //var olRepo = RepositoryHelper.GetOrderLineRepository(repo.UnitOfWork);
            //olRepo.Delete(olRepo.All().First(ol => ol.ProductId == id));

            var product = repo.Find(id);
            repo.Delete(product);

            repo.UnitOfWork.Commit();

            return RedirectToAction("Index");
        }

    }
}