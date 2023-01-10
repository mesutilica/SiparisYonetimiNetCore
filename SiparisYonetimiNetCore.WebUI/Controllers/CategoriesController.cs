using Microsoft.AspNetCore.Mvc;
using SiparisYonetimiNetCore.Entities;
using SiparisYonetimiNetCore.Service.Abstract;

namespace SiparisYonetimiNetCore.WebUI.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly IService<Category> _service; // standart servis
        private readonly ICategoryService _categoryService; // kategoriye özel yazdığımız servis

        public CategoriesController(IService<Category> service, ICategoryService categoryService)
        {
            _service = service;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> IndexAsync(int id)
        {
            var model = await _categoryService.GetCategoryByProducts(id); //_service.FindAsync(id);
            if (model is null) return BadRequest(); // BadRequest geçersiz istek hata sayfasını döndürür
            return View(model);
        }
    }
}
