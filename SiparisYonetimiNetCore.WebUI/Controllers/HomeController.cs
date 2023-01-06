using Microsoft.AspNetCore.Mvc;
using SiparisYonetimiNetCore.Entities;
using SiparisYonetimiNetCore.Service.Abstract;
using SiparisYonetimiNetCore.WebUI.Models;
using System.Diagnostics;

namespace SiparisYonetimiNetCore.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IService<Slide> _service;
        private readonly IService<Product> _serviceProduct;
        private readonly IService<Brand> _serviceBrand;

        public HomeController(IService<Slide> service, IService<Product> serviceProduct, IService<Brand> serviceBrand)
        {
            _service = service;
            _serviceProduct = serviceProduct;
            _serviceBrand = serviceBrand;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var model = new HomePageViewModel
            {
                Slides = await _service.GetAllAsync(),
                Products = await _serviceProduct.GetAllAsync(),
                Brands = await _serviceBrand.GetAllAsync()
            };

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}