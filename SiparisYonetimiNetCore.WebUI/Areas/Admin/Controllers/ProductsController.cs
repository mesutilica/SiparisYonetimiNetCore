using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SiparisYonetimiNetCore.Entities;
using SiparisYonetimiNetCore.Service.Abstract;
using SiparisYonetimiNetCore.WebUI.Utils;

namespace SiparisYonetimiNetCore.WebUI.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize]
    public class ProductsController : Controller
    {
        private readonly IService<Product> _service;
        private readonly IService<Category> _serviceCategory;
        private readonly IService<Brand> _serviceBrand;
        private readonly IProductService _ProductService;

        public ProductsController(IService<Product> service, IService<Category> serviceCategory, IService<Brand> serviceBrand, IProductService productService)
        {
            _service = service;
            _serviceCategory = serviceCategory;
            _serviceBrand = serviceBrand;
            _ProductService = productService;
        }

        // GET: ProductsController
        public async Task<ActionResult> Index()
        {
            var model = await _ProductService.GetProductsByCategoryAndBrandAsync();
            return View(model);
        }

        // GET: ProductsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductsController/Create
        public async Task<ActionResult> CreateAsync()
        {
            ViewBag.CategoryId = new SelectList(await _serviceCategory.GetAllAsync(), "Id", "Name");
            ViewBag.BrandId = new SelectList(await _serviceBrand.GetAllAsync(), "Id", "Name");
            return View();
        }

        // POST: ProductsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(Product product, IFormFile? Image)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (Image is not null) product.Image = await FileHelper.FileLoaderAsync(Image);
                    await _service.AddAsync(product);
                    await _service.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    ModelState.AddModelError("", "Hata Oluştu!");
                }
            }
            ViewBag.CategoryId = new SelectList(await _serviceCategory.GetAllAsync(), "Id", "Name");
            ViewBag.BrandId = new SelectList(await _serviceBrand.GetAllAsync(), "Id", "Name");
            return View(product);
        }

        // GET: ProductsController/Edit/5
        public async Task<ActionResult> EditAsync(int id)
        {
            ViewBag.CategoryId = new SelectList(await _serviceCategory.GetAllAsync(), "Id", "Name");
            ViewBag.BrandId = new SelectList(await _serviceBrand.GetAllAsync(), "Id", "Name");
            var model = await _service.FindAsync(id);
            return View(model);
        }

        // POST: ProductsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync(int id, Product product, IFormFile? Image)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (Image is not null) product.Image = await FileHelper.FileLoaderAsync(Image);
                    _service.Update(product);
                    await _service.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    ModelState.AddModelError("", "Hata Oluştu!");
                }
            }
            ViewBag.CategoryId = new SelectList(await _serviceCategory.GetAllAsync(), "Id", "Name");
            ViewBag.BrandId = new SelectList(await _serviceBrand.GetAllAsync(), "Id", "Name");
            return View(product);
        }

        // GET: ProductsController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var model = await _service.FindAsync(id);
            return View(model);
        }

        // POST: ProductsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteAsync(int id, Product product)
        {
            try
            {
                FileHelper.FileRemover(product.Image); // resmi sunucudan silmek için
                _service.Delete(product);
                await _service.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
