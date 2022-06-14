namespace Projekt.ViewModels
{
    public class OfferForListVM
    {
        public int Id { get; set; } 
        public string UserName { get; set; }
        public string Name { get; set; } 
        public string Location { get; set; }    
        public string Description { get; set; }
        public string FilePath { get; set; } 
        public DateTime Date { get; set; }
        public List <CategoryGroupsForListVM> Categories { get; set; }
    }
}
