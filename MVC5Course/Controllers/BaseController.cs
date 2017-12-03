namespace MVC5Course.Controllers
{
    using System.Web.Mvc;

    using MVC5Course.Models;

    public class BaseController : Controller
    {
        protected IProductRepository repo = RepositoryHelper.GetProductRepository();

        protected override void HandleUnknownAction(string actionName)
        {
            this.Redirect("/").ExecuteResult(this.ControllerContext);
            //base.HandleUnknownAction(actionName);
        }
    }
}