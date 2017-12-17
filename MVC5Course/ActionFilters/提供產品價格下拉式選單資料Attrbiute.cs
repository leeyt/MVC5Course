
namespace MVC5Course.ActionFilters
{
    using System.Linq;
    using System.Web.Mvc;

    using MVC5Course.Models;

    public class 提供產品價格下拉式選單資料Attrbiute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var db = new FabricsEntities();

            var prices = db.Product.AsEnumerable()
                .Select(p => new
                {
                    Text = string.Format("{0:C}", p.Price),
                    Value = p.Price
                })
                .Distinct()
                .OrderBy(p => p.Value);

            filterContext.Controller.ViewData["Price"] = new SelectList(prices, "Value", "Text");
        }
    }
}