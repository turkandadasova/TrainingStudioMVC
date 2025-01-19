using System.ComponentModel.DataAnnotations;

namespace TrainingStudioMVC.ViewModels.Specialization
{
    public class SpecializationUpdateVM
    {
        [MaxLength(32, ErrorMessage = "Name must be less than 32"), Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
    }
}
