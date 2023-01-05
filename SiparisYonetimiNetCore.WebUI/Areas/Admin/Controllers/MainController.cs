using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SiparisYonetimiNetCore.WebUI.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize] // Bu controller adimin areası içerisinde çalışacak
    public class MainController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
