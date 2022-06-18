using Projekt.Models;
using Projekt.Interfaces;
using Projekt.ViewModels;
namespace Projekt.Services
{
    public class OfferService : IOfferService
    {
        private readonly IOfferRepository _offerRepo;
        private readonly ICategoryGroupService _categoryGroupSerivce;
        public OfferService(IOfferRepository offerRepository, ICategoryGroupService categoryGroupService)
        {
            _offerRepo = offerRepository;
            _categoryGroupSerivce = categoryGroupService;
        }
       
        public void addOffer(Offer Offer)
        {

            _offerRepo.AddOffer(Offer);

        }

        public void EditOffer(int id,bool offerState)
        {
             var offers = _offerRepo.GetOfferById(id);
            offers.FirstOrDefault().isActive = offerState;
            //Offer result = new();
            //foreach (var offer in offers)
            //{
            //    result = new Offer()
            //    {
            //        Id = offer.Id,
            //        Name = offer.Name,
            //        Description = offer.Description,
            //        Location = offer.Location,
            //        FilePath = offer.FilePath,
            //        User = offer.User,
            //    };
            //}
           
            _offerRepo.EditOffer();
           
        }
        public Offer GetOfferById(int id)
        {
            var offers = _offerRepo.GetOfferById(id);
            foreach(var offer in offers)
            {
                Offer result= new Offer()
                {
                    Id = offer.Id,
                    Name = offer.Name,
                    Description = offer.Description,
                    Location = offer.Location,
                    FilePath = offer.FilePath,
                    User = offer.User,
                };
            return result;
            }
            return null;
        }

        public ListOfferForListVM GetOffersByLocation(string location)
        {
            ListOfferForListVM result = new ListOfferForListVM();
            result.Offers = new List<OfferForListVM>();

            var offers = _offerRepo.GetOffersByLocation(location);

            foreach (var offer in offers)
            {

                var oVM = new OfferForListVM()
                {
                    Id = offer.Id,
                    Name = offer.Name,
                    Description = offer.Description,
                    UserName = offer.User.UserName,
                    Location = offer.Location,
                    FilePath = offer.FilePath,

                };


                result.Offers.Add(oVM);
            }
            foreach (var offer in result.Offers)
            {
                offer.Categories = _categoryGroupSerivce.GetCategoryGroupsByOfferId(offer.Id);
            }

            return result;
        }

        public ListOfferForListVM GetOffersByName(string name)
        {
            ListOfferForListVM result = new ListOfferForListVM();
            result.Offers = new List<OfferForListVM>();

            var offers = _offerRepo.GetOffersByName(name);

            foreach (var offer in offers)
            {

                var oVM = new OfferForListVM()
                {
                    Id = offer.Id,
                    Name = offer.Name,
                    Description = offer.Description,
                    UserName = offer.User.UserName,
                    Location = offer.Location,
                    FilePath = offer.FilePath,

                };


                result.Offers.Add(oVM);
            }
            foreach (var offer in result.Offers)
            {
                offer.Categories = _categoryGroupSerivce.GetCategoryGroupsByOfferId(offer.Id);
            }

            return result;
        }

        public ListOfferForListVM GetOffersByUserId(string id)
        {
            ListOfferForListVM result = new ListOfferForListVM();
            result.Offers = new List<OfferForListVM>();

            var offers = _offerRepo.GetOfferByUserId(id);

            foreach (var offer in offers)
            {

                var oVM = new OfferForListVM()
                {
                    Id = offer.Id,
                    Name = offer.Name,
                    Description = offer.Description,
                    UserName = offer.User.UserName,
                    Location = offer.Location,
                    FilePath = offer.FilePath,

                };


                result.Offers.Add(oVM);
            }
            foreach (var offer in result.Offers)
            {
                offer.Categories = _categoryGroupSerivce.GetCategoryGroupsByOfferId(offer.Id);
            }

            return result;
        }

        public ListOfferForListVM GetOffersForList()
        {
            ListOfferForListVM result = new ListOfferForListVM();
           result.Offers = new List<OfferForListVM>();
           
            var offers = _offerRepo.GetAllOffers();

            foreach (var offer in offers)
            {
                
                var oVM = new OfferForListVM()
                {
                    Id = offer.Id,
                    Name = offer.Name,
                    Description = offer.Description,
                    UserName = offer.User.UserName,
                    Location = offer.Location,
                    FilePath = offer.FilePath,
               
            };

   
                result.Offers.Add(oVM);
            }
            foreach(var offer in result.Offers)
            {
                offer.Categories = _categoryGroupSerivce.GetCategoryGroupsByOfferId(offer.Id);
            }

            return result;
        }
    }
}
