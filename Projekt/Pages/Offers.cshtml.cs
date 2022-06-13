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

        private readonly IOfferService _offerService;
        private readonly ApplicationDbContext _context;
        public ListOfferForListVM Offers { get; set; }
        public List<Offer> Offer { get; set; }
        public OferrsModel(IOfferService offerService, ApplicationDbContext context)
        {
            _offerService = offerService;
            _context = context;
        }
        public void OnGet()
        {
            Offers = _offerService.GetOffersForList();
            Offer = _context.Offers.ToList();


        }
    }
}
