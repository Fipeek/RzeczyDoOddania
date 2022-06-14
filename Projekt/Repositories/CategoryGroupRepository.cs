using Projekt.Data;
using Projekt.Interfaces;
using Projekt.Models;
using Microsoft.EntityFrameworkCore;

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
            return _context.CategoryGroups.Include(c => c.Offer);
        }
        public IQueryable<CategoryGroup> GetCategoryGroupsByCategoryId(int id)
        {
            return _context.CategoryGroups.Include(c => c.Offer).Where(c => c.CategoryID == id);
        }
        public IQueryable<CategoryGroup> GetCategoryGroupsByName(string name)
        {
            return _context.CategoryGroups.Include(c => c.Offer).Where(c => c.Offer.Name == name);
        }
        public IQueryable<CategoryGroup> GetCategoryGroupsByLocation(string location)
        {
            return _context.CategoryGroups.Include(c => c.Offer).Where(c => c.Offer.Location == location);
        }

    }
}

