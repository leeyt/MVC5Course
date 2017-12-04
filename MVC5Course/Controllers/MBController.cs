namespace MVC5Course.Controllers
{
    using System.Web.Mvc;

    public class MBController : BaseController
    {
        public ActionResult Index()
        {
            var data = repo.Get取得所有尚未刪除的商品資料Top10();

            ViewData.Model = data;

            ViewBag.PageTitle = "商品資料";          

            return View();
        }
    }
}