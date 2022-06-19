using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Projekt.Data;
using Projekt.Interfaces;
using Projekt.ViewModels;
using Projekt.Models;
using Microsoft.AspNetCore.Authorization;

namespace Projekt.Pages.Offers
{
    public class OferrsModel : PageModel
    {
        public ListCategoriesForListVM Categories { get; set; }
        [BindProperty]
        public string SelectedField { get; set; }
        [BindProperty]
        public string SearchPhrase { get; set; }
        [BindProperty]
        public int SelectedCategoryID { get; set; }
        private readonly ICategoriesService _categoriesService;
        private readonly ICategoryGroupService _categoryGroupService;
        private readonly IOfferService _offerService;
  
        public ListOfferForListVM Offers { get; set; }
        public List<Offer> Offer { get; set; }
        public ListCategoryGroupsForListVM CategoriesGroups {get;set;}
        public OferrsModel(IOfferService offerService, ICategoriesService categoriesService, ICategoryGroupService categoryGroupService)
        {
            _offerService = offerService;
            _categoriesService = categoriesService;
            _categoryGroupService = categoryGroupService;
        }
        public void OnGet()
        {
            Offers = _offerService.GetOffersForList();
            Categories = _categoriesService.GetListCategoriesForListVM();
        }
        public async Task OnPost()
        {
         
            Categories = _categoriesService.GetListCategoriesForListVM();
            if(SelectedField == "Category")
            {
                Offers = _categoryGroupService.GetCategoryGroupsByCategoryId(SelectedCategoryID);

            }
            if (SelectedField == "Name")
            {
                Offers = _offerService.GetOffersByName(SearchPhrase);
            }
            if (SelectedField == "Location")
            {
                Offers = _offerService.GetOffersByLocation(SearchPhrase);
            }
        }
    }
}
