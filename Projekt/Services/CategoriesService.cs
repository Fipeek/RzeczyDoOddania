using Projekt.Interfaces;
using Projekt.Models;
using Projekt.ViewModels;
using Projekt.Repositories;
namespace Projekt.Services
{
    public class CategoriesService : ICategroiesService
    {
        private readonly ICategoriesRepository _categoriesRepository;
        public CategoriesService(ICategoriesRepository categoriesRepository)
        {
            _categoriesRepository = categoriesRepository;
        }
        public void addCategory(Category category)
        {
            _categoriesRepository.AddCategory(category);
        }

     

        public Category getCategoryById(int id)
        {
            return _categoriesRepository.getCategoryById(id);
        }

        public ListCategoriesForListVM GetListCategoriesForListVM()
        {
            var categories = _categoriesRepository.GetAllCategories();
            ListCategoriesForListVM result = new ();
            result.Categories= new List<CategoriesForListVM>();
            foreach (var category in categories)
            {
                var pVM = new CategoriesForListVM()
                {
                    
                    Name = category.Name,
                };
                result.Categories.Add(pVM);
            }
            return result;
        }
    }
}
