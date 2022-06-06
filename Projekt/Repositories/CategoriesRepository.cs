using Projekt.Data;
using Projekt.Interfaces;
using Projekt.Models;

namespace Projekt.Repositories
{
    public class CategoriesRepository : ICategoriesRepository
    {
        private readonly ApplicationDbContext _context;
        public CategoriesRepository(ApplicationDbContext context)
        {
            _context = context; 
        }
        public void AddCategory(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public IQueryable<Category> GetAllCategories()
        {
            return _context.Categories;
        }

       public Category getCategoryById(int id)
        {
            return _context.Categories.Where(x => x.Id == id).FirstOrDefault();
        }
    }
}
