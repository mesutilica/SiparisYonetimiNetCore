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
        private readonly IService<Contact> _serviceContact;

        public HomeController(IService<Slide> service, IService<Product> serviceProduct, IService<Brand> serviceBrand, IService<Contact> serviceContact)
        {
            _service = service;
            _serviceProduct = serviceProduct;
            _serviceBrand = serviceBrand;
            _serviceContact = serviceContact;
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
        [Route("iletisim")]
        public IActionResult ContactUs()
        {
            return View();
        }
        [Route("iletisim"), HttpPost]
        public async Task<IActionResult> ContactUsAsync(Contact contact)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _serviceContact.AddAsync(contact);
                    await _serviceContact.SaveChangesAsync();
                    TempData["Mesaj"] = "<div class='alert alert-success'>Mesajınız Gönderildi..</div>";
                    return RedirectToAction("ContactUs");
                }
                catch (Exception)
                {
                    ModelState.AddModelError("", "Hata Oluştu!");
                }
            }
            return View(contact);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}