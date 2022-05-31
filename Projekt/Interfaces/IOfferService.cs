using Projekt.ViewModels;
using Projekt.Models;
namespace Projekt.Interfaces
{
    public interface IOfferService
    {
        ListOfferForListVM GetOffersForList();
        void addOffer(Offer Offer);

    }
}
