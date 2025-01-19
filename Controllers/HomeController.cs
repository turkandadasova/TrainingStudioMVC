using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using TrainingStudioMVC.DataAccess;
using TrainingStudioMVC.Models;
using TrainingStudioMVC.ViewModels.Specialization;
using TrainingStudioMVC.ViewModels.Trainer;

namespace TrainingStudioMVC.Controllers
{
    public class HomeController(TrainingDbContext _context) : Controller
    {
       

        public async Task<IActionResult> Index()
        {
            var datas = await _context.Trainers.Where(x=>!x.IsDeleted).Select(x=>new TrainerItemVM
            {
                Name = x.Name,
                Surname=x.Surname,
                Details = x.Details,
                SpecializationId = x.SpecializationId,
            }).ToListAsync();
            return View(datas);
        }

       
    }
}
