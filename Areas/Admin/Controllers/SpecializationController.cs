using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrainingStudioMVC.DataAccess;
using TrainingStudioMVC.Models;
using TrainingStudioMVC.ViewModels.Specialization;
using TrainingStudioMVC.ViewModels.Specialization;

namespace TrainingStudioMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SpecializationController(TrainingDbContext _context) : Controller
    {
        // GET: SpecializationController
        public async Task<ActionResult> Index()
        {
            return View();
        }

        // GET: SpecializationController/Create
        public async Task<ActionResult> Create()
        {
            return View();
        }

        // POST: SpecializationController/Create
        [HttpPost]
        
        public async Task<ActionResult> Create(SpecializationCreateVM vm)
        {
            if(!ModelState.IsValid) return View();
            Specialization specialization = new Specialization
            {
                Name = vm.Name,
            };
            await _context.Specializations.AddAsync(specialization);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        // GET: SpecializationController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SpecializationController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SpecializationController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SpecializationController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
