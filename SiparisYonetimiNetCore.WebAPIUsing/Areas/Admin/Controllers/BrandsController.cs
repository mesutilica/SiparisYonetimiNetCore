using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SiparisYonetimiNetCore.Entities;
using SiparisYonetimiNetCore.Service.Abstract;
using SiparisYonetimiNetCore.WebUI.Utils;

namespace SiparisYonetimiNetCore.WebUI.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize(Policy = "AdminPolicy")]
    public class BrandsController : Controller
    {
        private readonly IService<Brand> _service;
        private readonly HttpClient _httpClient;
        private readonly string _apiAdres;

        public BrandsController(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _apiAdres = "https://localhost:7005/api/Brands";
        }

        // GET: BrandsController
        public async Task<ActionResult> Index()
        {
            var request = await _httpClient.GetFromJsonAsync<List<Brand>>(_apiAdres);
            return View(request);
        }

        // GET: BrandsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BrandsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BrandsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken] // uygulama dışından gelecek isteklete karşı güvenlik için
        public async Task<IActionResult> CreateAsync(Brand brand, IFormFile? Logo)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (Logo is not null) brand.Logo = await FileHelper.FileLoaderAsync(Logo);
                    await _service.AddAsync(brand);
                    await _service.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    ModelState.AddModelError("", "Hata Oluştu!");
                }
            }
            return View(brand);
        }

        // GET: BrandsController/Edit/5
        public ActionResult Edit(int id)
        {
            var model = _service.Find(id);
            return View(model);
        }

        // POST: BrandsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync(int id, Brand brand, IFormFile? Logo)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (Logo is not null) brand.Logo = await FileHelper.FileLoaderAsync(Logo);
                    _service.Update(brand);
                    await _service.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    ModelState.AddModelError("", "Hata Oluştu!");
                }
            }
            return View(brand);
        }

        // GET: BrandsController/Delete/5
        public ActionResult Delete(int id)
        {
            var model = _service.Find(id);
            return View(model);
        }

        // POST: BrandsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Brand brand)
        {
            try
            {
                _service.Delete(brand);
                _service.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
