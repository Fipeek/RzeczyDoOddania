using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        private readonly ICategoriesService _categoriesService;
        [BindProperty]
        [Required]
        public int SelectedOfferId { get; set; }
        [BindProperty]
        [Required]
        public bool OfferState { get; set; }
        public ListOfferForListVM Offers { get; set; }
        public User user { get; set; }
        public MyOffersModel(IOfferService offerService, ICategoriesService categoriesService)
        {
            _offerService = offerService;
            _categoriesService = categoriesService;
        }    
        public void OnGet()
        {
            var userClaims = (ClaimsIdentity)User.Identity;
            var claim = userClaims.FindFirst(ClaimTypes.NameIdentifier);
            string userId = claim.Value;
            Offers = _offerService.GetOffersByUserId(userId);
        }
        public async Task OnPost()
        {
            if (ModelState.IsValid)
            {
            _offerService.EditOffer(SelectedOfferId, OfferState);
            var userClaims = (ClaimsIdentity)User.Identity;
            var claim = userClaims.FindFirst(ClaimTypes.NameIdentifier);
            string userId = claim.Value;
            Offers = _offerService.GetOffersByUserId(userId);

            }
        }
    }
}
