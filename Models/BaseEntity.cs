using System.ComponentModel.DataAnnotations;

namespace TrainingStudioMVC.Models
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        [MaxLength(32)]
        public string Name { get; set; } = null!;
        public bool IsDeleted { get; set; } 
    }
}
