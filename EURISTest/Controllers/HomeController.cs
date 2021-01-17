using System.Web.Mvc;

namespace EURIS.Test.Controllers
{
  public class HomeController : Controller
  {
    public ActionResult Index()
    {
      ViewBag.Message = "Welcome to the EURIS Group ASP.NET MVC developer test application.";
      return View();
    }
  }
}
