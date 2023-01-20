using Microsoft.AspNetCore.Mvc;
using SiparisYonetimiNetCore.Entities;

namespace SiparisYonetimiNetCore.WebAPIUsing.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiAdres;

        public CategoriesController(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _apiAdres = "https://localhost:7005/api/Categories";
        }
        public async Task<IActionResult> IndexAsync(int id)
        {
            var model = await _httpClient.GetFromJsonAsync<Category>($"{_apiAdres}/{id}");
            return View(model);
        }
    }
}
