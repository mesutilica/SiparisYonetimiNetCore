using Microsoft.AspNetCore.Mvc;
using SiparisYonetimiNetCore.Entities;
using SiparisYonetimiNetCore.Service.Abstract;

namespace SiparisYonetimiNetCore.WebUI.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IService<Product> _serviceProduct;

        public ProductsController(IService<Product> serviceProduct)
        {
            _serviceProduct = serviceProduct;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var model = await _serviceProduct.GetAllAsync();
            return View(model);
        }
        public async Task<IActionResult> Search(string Kelime) // Kelime adres çubuğundan querystring yöntemiyle gönderiliyor
        {
            var model = await _serviceProduct.GetAllAsync(p => p.Name.Contains(Kelime));
            return View(model);
        }
        public async Task<IActionResult> DetailAsync(int id)
        {
            var model = await _serviceProduct.FindAsync(id);
            return View(model);
        }
    }
}
