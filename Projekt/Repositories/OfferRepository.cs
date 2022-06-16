using Projekt.Interfaces;
using Projekt.Models;
using Projekt.Data;
using Microsoft.EntityFrameworkCore;

namespace Projekt.Repositories
{
    public class OfferRepository : IOfferRepository
    {
        private readonly ApplicationDbContext _context;
        public OfferRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void AddOffer(Offer offer)
        {
            _context.Offers.Add(offer);
            _context.SaveChanges();
        }

        public IQueryable<Offer> GetAllOffers()
        {
            return _context.Offers.Include(o => o.User);
        }

        public IQueryable<Offer> GetOfferById(int id)
        {
            return _context.Offers.Include(o => o.User).Where(o => o.Id == id);
        }

        public IQueryable<Offer> GetOffersByLocation(string location)
        {
            return _context.Offers.Include(o => o.User).Where(o => o.Location == location);
        }

        public IQueryable<Offer> GetOffersByName(string name)
        {
            return _context.Offers.Include(o => o.User).Where(o => o.Name == name);
        }
    }
}
