using Projekt.Interfaces;
using Projekt.Models;
using Projekt.ViewModels;
namespace Projekt.Interfaces
{
    public interface ICategoriesService
    {
       ListCategoriesForListVM GetListCategoriesForListVM();
        void addCategory(Category category);
        Category getCategoryById(int id);
    }
}
