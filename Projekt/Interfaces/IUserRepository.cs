using Projekt.Models;
namespace Projekt.Interfaces
{
    public interface IUserRepository
    {
        IQueryable<User> GetAllUsers();
        void AddUser(User user);
        User GetUserById(String id);
    }
}
