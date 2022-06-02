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
        public ListCategoriesForListVM Categories { get; set; } 
        [BindProperty]
        public Offer Offer { get; set; }
        [BindProperty]
        public IFormFile UploadedFile { get; set; }

        public AddOfferModel(IOfferService offerService, UserManager<User> userManager,IUserService userService, IHostEnvironment hostEnvironment, ICategroiesService categroiesService)
        {
          _offerService = offerService;
            _userManager = userManager;
            _userService = userService; 
            _hostEnvironment = hostEnvironment;
            _categoriesService = categroiesService;
        }
        public void OnGet()
        {
            Categories = _categoriesService.GetListCategoriesForListVM();
        }
        public async Task OnPost()
        {

            if(UploadedFile == null || UploadedFile.Length == 0)
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

            if (ModelState.IsValid)
            {
                _offerService.addOffer(Offer);
            }
           /* return Page();*/
        }

        
    }
}
