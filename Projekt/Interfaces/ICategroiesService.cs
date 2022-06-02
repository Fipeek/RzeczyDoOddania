using Projekt.Interfaces;
using Projekt.Models;
using Projekt.ViewModels;
namespace Projekt.Interfaces
{
    public interface ICategroiesService
    {
       ListCategoriesForListVM GetListCategoriesForListVM();
        void addCategory(Category category);
        
    }
}
