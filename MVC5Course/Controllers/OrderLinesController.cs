
namespace MVC5Course.Controllers
{
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;

    using MVC5Course.Models;

    public class OrderLinesController : Controller
    {
        private FabricsEntities db = new FabricsEntities();

        // GET: OrderLines
        public ActionResult Index(int id)
        {
            var orderLine = db.OrderLine
                .Where(p => p.ProductId == id)
                .Include(o => o.Order)
                .Include(o => o.Product);
            return View(orderLine.ToList());
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
