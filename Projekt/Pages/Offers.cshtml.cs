using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Projekt.Data;
using Projekt.Interfaces;
using Projekt.ViewModels;
using Projekt.Models;
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
        private readonly ICategroiesService _categoriesService;
        private readonly ICategoryGroupService _categoryGroupService;
        private readonly IOfferService _offerService;
        private readonly ApplicationDbContext _context;
  
        public ListOfferForListVM Offers { get; set; }
        public List<Offer> Offer { get; set; }
        public ListCategoryGroupsForListVM CategoriesGroups {get;set;}
        public OferrsModel(IOfferService offerService, ApplicationDbContext context, ICategroiesService categroiesService, ICategoryGroupService categoryGroupService)
        {
            _offerService = offerService;
            _context = context;
            _categoriesService = categroiesService;
            _categoryGroupService = categoryGroupService;


        }
        public void OnGet()
        {
            Offers = _offerService.GetOffersForList();
            Offer = _context.Offers.ToList();
            Categories = _categoriesService.GetListCategoriesForListVM();
            CategoriesGroups = _categoryGroupService.GetListCategoryGroupForListVM();
        }
        public async Task OnPost()
        {
            Offers = _offerService.GetOffersForList();
            Offer = _context.Offers.ToList();
            Categories = _categoriesService.GetListCategoriesForListVM();
            if(SelectedField == "Category")
            {
                CategoriesGroups = _categoryGroupService.GetCategoryGroupsByCategoryId(SelectedCategoryID);
            }
            if (SelectedField == "Name")
            {
                CategoriesGroups = _categoryGroupService.GetCategoryGroupsByName(SearchPhrase);
            }
            if (SelectedField == "Location")
            {
                CategoriesGroups = _categoryGroupService.GetCategoryGroupsByLocation(SearchPhrase);
            }
        
            

        }

    }
}
