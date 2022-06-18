using Projekt.Models;
namespace Projekt.Interfaces
{
    public interface IOfferRepository
    {
        IQueryable<Offer> GetAllOffers();
        void AddOffer(Offer offer);
        IQueryable<Offer> GetOffersByName(string name);
        IQueryable<Offer> GetOffersByLocation(string location);
        IQueryable<Offer> GetOfferById(int id);
        IQueryable<Offer> GetOfferByUserId(string id);
        void EditOffer();
    }
}
