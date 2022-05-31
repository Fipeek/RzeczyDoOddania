using Projekt.Models;
using Projekt.Interfaces;
using Projekt.ViewModels;
namespace Projekt.Services
{
    public class OfferService : IOfferService
    {
        private readonly IOfferRepository _offerRepo;
        public OfferService(IOfferRepository offerRepository)
        {
            _offerRepo = offerRepository;
        }
       
        public void addOffer(Offer Offer)
        {

            _offerRepo.AddOffer(Offer);

        }

        public ListOfferForListVM GetOffersForList()
        {
            ListOfferForListVM result = new ListOfferForListVM();
           result.Offers = new List<OfferForListVM>();
           
            var offers = _offerRepo.GetAllOffers();




            foreach (var offer in offers)
            {
                User User = offer.User;
                var pVM = new OfferForListVM()
                {
                    Id = offer.Id,
                    Name = offer.Name,
                    Description = offer.Description,
                    UserName = offer.User.UserName,
                    Location = offer.Location,
                    FilePath = offer.FilePath,
                };
                result.Offers.Add(pVM);
            }

            return result;
        }
    }
}
