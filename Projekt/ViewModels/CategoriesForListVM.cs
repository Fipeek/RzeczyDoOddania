
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Projekt.ViewModels
{
    public class CategoriesForListVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<SelectListItem> SelectCategories { set; get; }
    }
}
