using Microsoft.AspNetCore.Mvc;

namespace SiparisYonetimiNetCore.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")] // Bu controller adimin areası içerisinde çalışacak
    public class MainController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
