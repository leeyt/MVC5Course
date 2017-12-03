namespace MVC5Course.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    public class ARController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PartialViewTest()
        {
            return PartialView("Index");
        }

        public ActionResult ContentTest()
        {
            // 這樣寫會導致維護性降低，不太方便管理!
            return Content("<script>alert('OK'); location.href='/';</script>");
        }

        public ActionResult ContentTest_Better()
        {
            return PartialView("JsAlertRedirect", "新增成功");
        }

        public ActionResult FileTest(int? dl = 0)
        {
            return dl == null
                ? File(Server.MapPath("~/App_Data/HNCK1202-2.jpg"), "image/jpeg")
                : File(Server.MapPath("~/App_Data/HNCK1202-2.jpg"), "image/jpeg", "IPhoneBroken.jpg");
        }

        public ActionResult JsonTest()
        {
            var data = (from p in this.repo.All()
                       select new
                       {
                           p.ProductId,
                           p.ProductName,
                           p.Price
                       }).Take(3);

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult RedirectTest()
        {
            return RedirectToAction("FileTest", new { dl = 1 });
        }

        public ActionResult RedirectTest2()
        {
            return RedirectToRoute(new
            {
                controller = "Home",
                action = "Index",
                id = 123
            });
        }
    }
}