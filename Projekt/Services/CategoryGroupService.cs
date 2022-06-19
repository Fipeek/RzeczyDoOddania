using Projekt.Interfaces;
using Projekt.Models;
using Projekt.ViewModels;
using Projekt.Repositories;

namespace Projekt.Services
{
	public class CategoryGroupService : ICategoryGroupService
	{
        private readonly ICategoryGroupRepository _categoryGroupRepository;
        private readonly IOfferRepository _offerRepository;
        private readonly ICategroiesService _categoriesSerivce;
        public CategoryGroupService(ICategoryGroupRepository categoryGroupRepository, IOfferRepository offerRepository, ICategroiesService categoriesService)
		{
            _categoryGroupRepository = categoryGroupRepository;
            _offerRepository = offerRepository;
            _categoriesSerivce = categoriesService;
        }

        public void addCategoryGroup(CategoryGroup categoryGroup)
        {
            _categoryGroupRepository.AddCategoryGroup(categoryGroup);
        }
        public List<Category> GetCategoryGroupsByOfferId(int id)
        {
            var categoryGroups = _categoryGroupRepository.GetCategoryGroupsByOfferId(id);

            List<Category> result = new();
            foreach (var categoryGroup in categoryGroups)
            {
              
                var cVM = new Category()
                {
                    Id = categoryGroup.Category.Id,
                    Name = categoryGroup.Category.Name,
                };
                result.Add(cVM);
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

        public ListOfferForListVM GetCategoryGroupsByCategoryId(int id)
        {
            var categoryGroups = _categoryGroupRepository.GetCategoryGroupsByCategoryId(id);
        
            ListOfferForListVM result = new();
            result.Offers = new();
            foreach(var categoryGroup in categoryGroups)
            {
                var oVM = new OfferForListVM()
                {
                    Id = categoryGroup.OfferID,
                    Name = categoryGroup.Offer.Name,
                    Location = categoryGroup.Offer.Location,
                    Date = categoryGroup.Offer.Date,
                    Description = categoryGroup.Offer.Description,
                    FilePath = categoryGroup.Offer.FilePath,
                    IsActive = categoryGroup.Offer.isActive,

                };
                result.Offers.Add(oVM);
            }
            foreach(var offer in result.Offers)
            {
                offer.Categories = this.GetCategoryGroupsByOfferId(offer.Id);
                var repoOffers = _offerRepository.GetOfferById(offer.Id);
                foreach (var repoOffer in repoOffers)
                {
                    offer.UserName = repoOffer.User.UserName;
                }
            }
           
            foreach (var offer in result.Offers)
            {
             
        
            }
            return result;
        }
    }
}

