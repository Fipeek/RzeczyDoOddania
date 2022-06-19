using System.ComponentModel.DataAnnotations;

namespace Projekt.Models
{
    public class Offer
    {

        public int Id { get; set; } 
        public  User? User { get; set; }
        [Required]
        [Display(Name = "Lokacja")]
        public string Location { get; set; }
        [Display(Name = "nazwa")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "opis")]
        public string Description { get; set; }
        [Required]
        [Display(Name = "data")]
        public DateTime Date { get; set; }
        public string? FilePath { get; set; }
        public ICollection<CategoryGroup>? CategoryGroups { get; set; }
        public bool isActive { get; set; }
    }
}
