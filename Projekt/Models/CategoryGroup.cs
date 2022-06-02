namespace Projekt.Models
{
    public class CategoryGroup
    {
        public int OfferID { get; set; }
        public Offer Offer { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
