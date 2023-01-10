using Microsoft.AspNetCore.Mvc;
using SiparisYonetimiNetCore.Service.Abstract;

namespace SiparisYonetimiNetCore.WebUI.Controllers
{
    public class BrandsController : Controller
    {
        private readonly IBrandService _brandService;

        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        public async Task<IActionResult> IndexAsync(int id)
        {
            var model = await _brandService.GetBrandByProducts(id);
            if (model is null) return BadRequest(); // BadRequest geçersiz istek hata sayfasını döndürür
            return View(model);
        }
    }
}
