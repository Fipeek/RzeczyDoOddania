using Projekt.Interfaces;
using Projekt.Models;
using Projekt.ViewModels;
using Projekt.Repositories;

namespace Projekt.Services
{
	public class CategoryGroupService : ICategoryGroupService
	{
        private readonly ICategoryGroupRepository _categoryGroupRepository;
        public CategoryGroupService(ICategoryGroupRepository categoryGroupRepository)
		{
            _categoryGroupRepository = categoryGroupRepository;
        }

        public void addCategoryGroup(CategoryGroup categoryGroup)
        {
            _categoryGroupRepository.AddCategoryGroup(categoryGroup);
        }

        public ListCategoryGroupsForListVM GetListCategoryGroupForListVM()
        {
            var categoryGroups = _categoryGroupRepository.GetAllCategoryGroups();
            ListCategoryGroupsForListVM result = new();
            result.CategoryGroups = new List<CategoryGroupsForListVM>();
            foreach (var categoryGroup in categoryGroups)
            {
                var pVM = new CategoryGroupsForListVM()
                {
                    OfferID = categoryGroup.OfferID,
                    CategoryID = categoryGroup.CategoryID,
                    
                };
                result.CategoryGroups.Add(pVM);
            }
            return result;
        }
    }
}

