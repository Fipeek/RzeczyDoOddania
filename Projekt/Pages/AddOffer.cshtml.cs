using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Projekt.Models;
using Projekt.Interfaces;
using Projekt.ViewModels;
using Microsoft.AspNetCore.Identity;
using Projekt.Data;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System.IO;

namespace Projekt.Pages.AddOffer
{
    [Authorize]
    public class AddOfferModel : PageModel
    {
        private readonly IOfferService _offerService;
        private readonly IUserService _userService;
        private readonly UserManager<User> _userManager;
        private readonly IHostEnvironment _hostEnvironment;
        private readonly ICategroiesService _categoriesService;
        private readonly ICategoryGroupService _categoryGroupService;
        [BindProperty]
        public Category Category1 { get; set; }
        [BindProperty]
        public Category Category2 { get; set; }
        [BindProperty]
        public int Category1Id { get; set; }
        [BindProperty]
        public int Category2Id { get; set; }
        public CategoryGroup CategoryGroup { get; set; }
        public CategoryGroup CategoryGroup2 { get; set; }
        public ListCategoriesForListVM Categories { get; set; } 
        [BindProperty]
        public Offer Offer { get; set; }
        [BindProperty]
        public IFormFile UploadedFile { get; set; }

        public AddOfferModel(IOfferService offerService, UserManager<User> userManager,IUserService userService, IHostEnvironment hostEnvironment, ICategroiesService categroiesService, ICategoryGroupService categoryGroupService)
        {
            _offerService = offerService;
            _userManager = userManager;
            _userService = userService; 
            _hostEnvironment = hostEnvironment;
            _categoriesService = categroiesService;
            _categoryGroupService = categoryGroupService;
        }
        public void OnGet()
        {
            Categories = _categoriesService.GetListCategoriesForListVM();
        }
        public async Task OnPost()
        {
            Categories = _categoriesService.GetListCategoriesForListVM();

            if (UploadedFile == null || UploadedFile.Length == 0)
            {
                return;
            }
            string targetFileName = $"{_hostEnvironment.ContentRootPath}/wwwroot/{UploadedFile.FileName}";
            using (var stream = new FileStream(targetFileName, FileMode.Create))
            {
                await UploadedFile.CopyToAsync(stream);
            }
            var test = (ClaimsIdentity)User.Identity;
            var claim = test.FindFirst(ClaimTypes.NameIdentifier);
            Offer.FilePath = $"{UploadedFile.FileName}";
            Offer.User = _userService.GetUserById(claim.Value);

            if (!ModelState.IsValid)
            {
                
                _offerService.addOffer(Offer);
                CategoryGroup = new CategoryGroup(Offer, _categoriesService.getCategoryById(Category1Id));
                CategoryGroup2 = new CategoryGroup(Offer, _categoriesService.getCategoryById(Category2Id));
                _categoryGroupService.addCategoryGroup(CategoryGroup);
                _categoryGroupService.addCategoryGroup(CategoryGroup2);
                Response.Redirect("/Offers");
         
            }
          
        }

        
    }
}
