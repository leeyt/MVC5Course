namespace MVC5Course.Controllers
{
    using System.Web.Mvc;
    public class ARController : Controller
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
    }
}