using Microsoft.EntityFrameworkCore;
using TrainingStudioMVC.Models;

namespace TrainingStudioMVC.DataAccess
{
    public class TrainingDbContext:DbContext
    {
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<Specialization> Specializations { get; set; }

        public TrainingDbContext(DbContextOptions opt):base(opt)
        {
            
        }
        
    }
}
