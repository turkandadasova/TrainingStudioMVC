using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrainingStudioMVC.DataAccess;
using TrainingStudioMVC.Models;
using TrainingStudioMVC.ViewModels.Specialization;
using TrainingStudioMVC.ViewModels.Trainer;

namespace TrainingStudioMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TrainerController(TrainingDbContext _context,IWebHostEnvironment _env) : Controller
    {
        // GET: TrainerController
        public async Task<ActionResult> Index()
        {
            return View(await _context.Trainers.ToListAsync());
        }


        // GET: TrainerController/Create
        public async Task<ActionResult> Create()
        {
            return View();
        }

        // POST: TrainerController/Create
        [HttpPost]
        public async Task<ActionResult> Create(TrainerCreateVM vm)
        {
            if (!ModelState.IsValid) return BadRequest();
            if(!vm.File.ContentType.StartsWith("image"))
            {
                ModelState.AddModelError("File", "File type must be image");
                return View();
            }
            if(vm.File.Length>6*1024*1024)
            {
                ModelState.AddModelError("File", "File length must be less than 6mb");
                return View();
            }
           string newFileName=Path.GetRandomFileName()+Path.GetExtension(vm.File.FileName);
            using(Stream stream=System.IO.File.Create(Path.Combine(_env.WebRootPath,"imgs","trainers",newFileName)))
            {
                await vm.File.CopyToAsync(stream);
            }
            Trainer trainer = new Trainer
            {
                CoverImage = newFileName,
                Name = vm.Name,
                Surname = vm.Surname,
                Details = vm.Details,
                SpecializationId = vm.SpecializationId,
            };
            await _context.Trainers.AddAsync(trainer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            return RedirectToAction(nameof(Index));
        }

        // GET: TrainerController/Edit/5
        public async Task<ActionResult> Update(int? id)
        {
            if (id is null) return BadRequest();
            var data = await _context.Trainers.Where(x => x.Id == id).Select(x => new TrainerUpdateVM
            {
                Name = x.Name,
                Surname= x.Surname,
                Details = x.Details,
                SpecializationId = x.SpecializationId,
            }).FirstOrDefaultAsync();
            if (data is null) return NotFound();
            return View(data);
        }

        // POST: TrainerController/Edit/5
        [HttpPost]
        public async Task<ActionResult> Update(int? id, TrainerUpdateVM vm)
        {
            if (id is null) return BadRequest();
            var data = await _context.Trainers.FindAsync(id);
            if (vm.File != null)
            {
                if (!vm.File.ContentType.StartsWith("image"))
                    ModelState.AddModelError("File", "File type must be an image");
                if (vm.File.Length > 6 * 1024 * 1024)
                    ModelState.AddModelError("File", "File must be less than 6mb");
            }
            if (data is null) return NotFound();
            if (!ModelState.IsValid) return View(vm);
            if (vm.File != null)
            {
                string path = Path.Combine(_env.WebRootPath, "imgs", "trainers", data.CoverImage);
                using (Stream sr = System.IO.File.Create(path))
                {
                    await vm.File!.CopyToAsync(sr);
                }
            }
            data.Name = vm.Name;
            data.Surname = vm.Surname;
            data.Details = vm.Details;
            data.SpecializationId = vm.SpecializationId;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: TrainerController/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {

            if (!id.HasValue) return BadRequest();
            var data = await _context.Trainers.FindAsync(id);
            if (data is null) return NotFound();
            string oldFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "imgs", "trainers", data.CoverImage);

            if (System.IO.File.Exists(oldFilePath))
            {
                System.IO.File.Delete(oldFilePath);
            }
            _context.Trainers.Remove(data);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
