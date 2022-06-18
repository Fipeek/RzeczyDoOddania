using Projekt.ViewModels;
using Projekt.Models;
namespace Projekt.Interfaces
{
    public interface IOfferService
    {
        ListOfferForListVM GetOffersForList();
        void addOffer(Offer Offer);
        ListOfferForListVM GetOffersByName(string name);
        ListOfferForListVM GetOffersByLocation(string location);
        Offer GetOfferById(int id);
        ListOfferForListVM GetOffersByUserId(string id);
        void EditOffer(int id,bool offerState);

    }
}
