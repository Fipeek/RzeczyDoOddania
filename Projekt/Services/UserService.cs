using Projekt.Interfaces;
using Projekt.Models;
using Projekt.ViewModels;
using Projekt.Repositories;

namespace Projekt.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepo;
        public void AddUser(User user)
        {
            _userRepo.AddUser(user);
        }
        public UserService(IUserRepository userRepository)
        {
            _userRepo = userRepository; 
        }
        public User GetUserById(string id)
        {
          User User= _userRepo.GetUserById(id);
            return User;
        }

        public ListUserForListVM GetUsersForList()
        {
            var users = _userRepo.GetAllUsers();
            ListUserForListVM result = new ListUserForListVM();
            result.Users = new List<UserForListVM>();
            foreach (var user in users)
            {
                var pVM = new UserForListVM()
                {
                    Id = user.Id,
                    UserName = user.UserName,
                };
                result.Users.Add(pVM);
            }
            return result;
        }
    }
}
