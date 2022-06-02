using Projekt.Models;

namespace Projekt.Interfaces
{
    public interface ICategoriesRepository
    {
        IQueryable<Category> GetAllCategories();
        void AddCategory(Category category);
    }
}
