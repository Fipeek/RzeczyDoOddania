using Projekt.Models;
namespace Projekt.Interfaces
{
    public interface IOfferRepository
    {
        IQueryable<Offer> GetAllOffers();
        void AddOffer(Offer offer);

    }
}
