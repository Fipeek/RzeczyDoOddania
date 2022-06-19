using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Projekt.Interfaces;
using Projekt.Models;
using Projekt.ViewModels;

namespace Projekt.Pages
{
    [Authorize]
    public class MyOffersModel : PageModel
    {
        private readonly IOfferService _offerService;
        private readonly IUserService _userService;
        private readonly IHostEnvironment _hostEnvironment;
        private readonly ICategroiesService _categoriesService;
        private readonly ICategoryGroupService _categoryGroupService;
        [BindProperty]
        public int SelectedOfferId { get; set; }
        [BindProperty]
        public bool OfferState { get; set; }
        public ListOfferForListVM Offers { get; set; }
        public User user { get; set; }
        public MyOffersModel(IOfferService offerService, ICategroiesService categroiesService, ICategoryGroupService categoryGroupService)
        {
            _offerService = offerService;
            _categoriesService = categroiesService;
            _categoryGroupService = categoryGroupService;
        }
        public void OnGet()
        {
            var test = (ClaimsIdentity)User.Identity;
            var claim = test.FindFirst(ClaimTypes.NameIdentifier);
            string userId = claim.Value;
            Offers = _offerService.GetOffersByUserId(userId);
        }
        public async Task OnPost()
        {
            Offer SelectedOffer = _offerService.GetOfferById(SelectedOfferId);
            SelectedOffer.isActive = OfferState;
            var test = (ClaimsIdentity)User.Identity;
            var claim = test.FindFirst(ClaimTypes.NameIdentifier);
            string userId = claim.Value;
            Offers = _offerService.GetOffersByUserId(userId);
        }
    }
}
