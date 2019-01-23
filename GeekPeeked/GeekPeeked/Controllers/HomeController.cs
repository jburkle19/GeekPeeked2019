using System.Web.Mvc;

namespace GeekPeeked.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}