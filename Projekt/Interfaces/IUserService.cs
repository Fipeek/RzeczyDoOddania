using Projekt.ViewModels;
using Projekt.Models;
namespace Projekt.Interfaces

{
    public interface IUserService
    {
        ListUserForListVM GetUsersForList();
        void AddUser(User user);
        User GetUserById(String id);

    }
}
