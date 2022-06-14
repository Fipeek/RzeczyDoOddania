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

        public ListCategoryGroupsForListVM GetCategoryGroupsByCategoryId(int id)
        {

            var categoryGroups = _categoryGroupRepository.GetCategoryGroupsByCategoryId(id);
       
            ListCategoryGroupsForListVM result = new();
            result.CategoryGroups = new List<CategoryGroupsForListVM>();
            foreach (var categoryGroup in categoryGroups)
            {
                var pVM = new CategoryGroupsForListVM()
                {
                    OfferID = categoryGroup.OfferID,
                    CategoryID = categoryGroup.CategoryID,
                    Offer= categoryGroup.Offer,
                    Category=categoryGroup.Category,

                };
                result.CategoryGroups.Add(pVM);
            }
            return result;
        }

        public ListCategoryGroupsForListVM GetCategoryGroupsByLocation(string location)
        {
            var categoryGroups = _categoryGroupRepository.GetCategoryGroupsByLocation(location);
            ListCategoryGroupsForListVM result = new();
            result.CategoryGroups = new List<CategoryGroupsForListVM>();
            foreach (var categoryGroup in categoryGroups)
            {
                var pVM = new CategoryGroupsForListVM()
                {
                    OfferID = categoryGroup.OfferID,
                    CategoryID = categoryGroup.CategoryID,
                    Offer = categoryGroup.Offer,
                    Category = categoryGroup.Category,
                };
                result.CategoryGroups.Add(pVM);
            }
            return result;
        }

   
        public ListCategoryGroupsForListVM GetCategoryGroupsByName(string name)
        {
            var categoryGroups = _categoryGroupRepository.GetCategoryGroupsByName(name);
        ListCategoryGroupsForListVM result = new();
            result.CategoryGroups = new List<CategoryGroupsForListVM>();
            foreach (var categoryGroup in categoryGroups)
            {
                var pVM = new CategoryGroupsForListVM()
                {
                    OfferID = categoryGroup.OfferID,
                    CategoryID = categoryGroup.CategoryID,
                    Offer = categoryGroup.Offer,
                    Category = categoryGroup.Category,
                };
                result.CategoryGroups.Add(pVM);
            }
            return result;
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
                    Offer = categoryGroup.Offer,
                    Category = categoryGroup.Category,
                };
                result.CategoryGroups.Add(pVM);
            }
            return result;
        }
    }
}

