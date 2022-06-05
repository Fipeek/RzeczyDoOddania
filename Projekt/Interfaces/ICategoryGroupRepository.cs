using Projekt.Models;

namespace Projekt.Interfaces
{
	public interface ICategoryGroupRepository
	{
		IQueryable<CategoryGroup> GetAllCategoryGroups();
		void AddCategoryGroup(CategoryGroup categoryGroup);
	}
}

