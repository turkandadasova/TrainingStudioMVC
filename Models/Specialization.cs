namespace TrainingStudioMVC.Models
{
    public class Specialization:BaseEntity
    {
        ICollection<Trainer>? Trainers { get; set; }
    }
}
