using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using TrainingStudioMVC.DataAccess;
using TrainingStudioMVC.Models;
using TrainingStudioMVC.ViewModels.Specialization;

namespace TrainingStudioMVC.Controllers
{
    public class HomeController(TrainingDbContext _context) : Controller
    {
       

        public async Task<IActionResult> Index()
        {
            var datas = await _context.Specializations.Where(x=>!x.IsDeleted).Select(x=>new SpecializationItemVM
            {
                Name = x.Name,
            }).ToListAsync();
            return View(datas);
        }

       
    }
}
