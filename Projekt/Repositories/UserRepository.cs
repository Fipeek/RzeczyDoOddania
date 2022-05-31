using Projekt.Interfaces;
using Projekt.Models;
using Projekt.Data;

namespace Projekt.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void AddUser(User User)
        {
            _context.Users.Add(User);
            _context.SaveChanges();
        }

        public IQueryable<User> GetAllUsers()
        {
            return _context.Users;
        }

        public User GetUserById(string id)
        {
           return _context.Users.Where(x => x.Id == id).FirstOrDefault();
        }
    }
}
