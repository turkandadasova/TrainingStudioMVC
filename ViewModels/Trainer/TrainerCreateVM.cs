using System.ComponentModel.DataAnnotations;

namespace TrainingStudioMVC.ViewModels.Trainer
{
    public class TrainerCreateVM
    {
        [MaxLength(32, ErrorMessage = "Name must be less than 32"), Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [MaxLength(32, ErrorMessage = "Name must be less than 32"), Required(ErrorMessage = "Surname is required")]
        public string Surname { get; set; } = null!;
      
        public IFormFile File { get; set; } = null!;
        [MaxLength(128)]
        public string Details { get; set; }= null!;
        public int? SpecializationId { get; set; }
    }
}
