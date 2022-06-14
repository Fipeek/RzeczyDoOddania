using Projekt.Models;
namespace Projekt.ViewModels
{
    public class CategoryGroupsForListVM
    {
        public int OfferID { get; set; }
        public int CategoryID { get; set; }
        public Offer Offer { get; set; }
        public Category Category { get; set; }
    }
}
