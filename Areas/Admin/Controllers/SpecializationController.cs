using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            return View(await _context.Specializations.ToListAsync());
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
        public async Task<ActionResult> Update(int? id)
        {
            if (id is null) return BadRequest();
            var data =await _context.Specializations.Where(x=>x.Id == id).Select(x => new SpecializationUpdateVM
            {
                Name=x.Name,
            }).FirstOrDefaultAsync();
            if(data is null) return NotFound();
            return View(data);
        }

        // POST: SpecializationController/Edit/5
        [HttpPost]
        public async Task<ActionResult> Update(int? id, SpecializationUpdateVM vm)
        {
            if (id is null) return BadRequest();
            var data = await _context.Specializations.FindAsync( id);
            if (data is null) return NotFound();
            if(!ModelState.IsValid) return View(vm);
            data.Name = vm.Name;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: SpecializationController/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if(!id.HasValue) return BadRequest();
            var data = await _context.Specializations.FindAsync(id);
            if(data is null) return NotFound();
            _context.Specializations.Remove(data);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        
    }
}
