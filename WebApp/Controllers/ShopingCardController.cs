using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class ShopingCardController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }
    }
}
