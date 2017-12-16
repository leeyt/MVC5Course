namespace MVC5Course.Controllers
{
    using System;
    using System.Web.Mvc;

    public class MBBatchUpdateVM
    {
        public int ProductId { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<bool> Active { get; set; }
        public Nullable<decimal> Stock { get; set; }
    }

    public class MBController : BaseController
    {
        public ActionResult Index()
        {
            var data = repo.Get取得所有尚未刪除的商品資料Top10();

            ViewData.Model = data;

            ViewBag.PageTitle = "商品資料";          

            return View();
        }

        [HttpPost]
        public ActionResult Index(MBBatchUpdateVM[] batch)
        {
            if (ModelState.IsValid)
            {
                foreach (var item in batch)
                {
                    var one = repo.Find(item.ProductId);
                    one.Price = item.Price;
                    one.Active = item.Active;
                    one.Stock = item.Stock;
                }

                repo.UnitOfWork.Commit();

                return RedirectToAction("Index");
            }

            var data = repo.Get取得所有尚未刪除的商品資料Top10();
            ViewData.Model = data;
            ViewBag.PageTitle = "商品清單";
            return View();
        }
    }
}