namespace Projekt.Models
{
    public class CategoryGroup
    {
        public int OfferID { get; set; }
        public Offer? Offer { get; set; }
        public int CategoryID { get; set; }
        public Category? Category { get; set; }

        public CategoryGroup(Offer offer, Category category)
        {
            Offer = offer;
            Category = category;
            OfferID = offer.Id;
            CategoryID = category.Id;
        }

        public CategoryGroup() { }
    }
}
