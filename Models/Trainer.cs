using System.ComponentModel.DataAnnotations;

namespace TrainingStudioMVC.Models
{
    public class Trainer:BaseEntity
    {
        [MaxLength(32)]
        public string Surname { get; set; } = null!;
        [MaxLength(100)]
        public string CoverImage { get; set; }=null!;
        public string Details { get; set; } 
        public int? SpecializationId { get; set; }
        public Specialization? specialization { get; set; }
    }
}
