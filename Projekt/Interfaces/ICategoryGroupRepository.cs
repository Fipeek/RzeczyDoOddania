using Projekt.Models;

namespace Projekt.Interfaces
{
	public interface ICategoryGroupRepository
	{
		IQueryable<CategoryGroup> GetAllCategoryGroups();
		void AddCategoryGroup(CategoryGroup categoryGroup);
		IQueryable<CategoryGroup> GetCategoryGroupsByCategoryId(int id);
		public IQueryable<CategoryGroup> GetCategoryGroupsByLocation(string location);
		public IQueryable<CategoryGroup> GetCategoryGroupsByName(string name);
		public IQueryable<CategoryGroup> GetCategoryGroupsByOfferId(int id);
    }
}

