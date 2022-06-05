using Projekt.Data;
using Projekt.Interfaces;
using Projekt.Models;

namespace Projekt.Repositories
{
	public class CategoryGroupRepository : ICategoryGroupRepository
	{
        private readonly ApplicationDbContext _context;
        public CategoryGroupRepository(ApplicationDbContext context)
		{
            _context = context;
        }

        public void AddCategoryGroup(CategoryGroup categoryGroup)
        {
            _context.CategoryGroups.Add(categoryGroup);
            _context.SaveChanges();
        }

        public IQueryable<CategoryGroup> GetAllCategoryGroups()
        {
            return _context.CategoryGroups;
        }
    }
}

