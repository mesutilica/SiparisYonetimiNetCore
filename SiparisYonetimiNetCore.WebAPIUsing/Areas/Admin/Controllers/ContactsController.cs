using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SiparisYonetimiNetCore.Entities;
using SiparisYonetimiNetCore.Service.Abstract;

namespace SiparisYonetimiNetCore.WebUI.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize]
    public class ContactsController : Controller
    {
        private readonly IService<Contact> _service;

        public ContactsController(IService<Contact> service)
        {
            _service = service;
        }

        // GET: ContactsController
        public async Task<ActionResult> Index()
        {
            var model = await _service.GetAllAsync();
            return View(model);
        }

        // GET: ContactsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ContactsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ContactsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(Contact contact)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _service.AddAsync(contact);
                    await _service.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    ModelState.AddModelError("", "Hata Oluştu!");
                }
            }
            return View(contact);
        }

        // GET: ContactsController/Edit/5
        public ActionResult Edit(int id)
        {
            var model = _service.Find(id);
            return View(model);
        }

        // POST: ContactsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync(int id, Contact contact)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _service.Update(contact);
                    await _service.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    ModelState.AddModelError("", "Hata Oluştu!");
                }
            }
            return View(contact);
        }

        // GET: ContactsController/Delete/5
        public ActionResult Delete(int id)
        {
            var model = _service.Find(id);
            return View(model);
        }

        // POST: ContactsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Contact contact)
        {
            try
            {
                _service.Delete(contact);
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
