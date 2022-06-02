using System.ComponentModel.DataAnnotations;

namespace Projekt.Models
{
    public class Offer
    {
        public int Id { get; set; }

     
        public  User? User { get; set; }
        public string Location { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public string? FilePath { get; set; }
        public ICollection<CategoryGroup>? CategoryGroups { get; set; }

    }
}
