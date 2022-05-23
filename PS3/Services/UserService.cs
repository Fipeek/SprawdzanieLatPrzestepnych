using PS3.Interfaces;
using PS3.Models;
using PS3.ViewModels.User;

namespace PS3.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepo;
        public UserService(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        public ListUserForListVM GetUsersForList()
        {
            var users = _userRepo.GetAllUsers();
            ListUserForListVM result = new ListUserForListVM();
            result.Users = new List<UserForListVM>();
            foreach (var user in users)
            {
                // mapowanie obiektow
                var pVM = new UserForListVM()
                {
                    Id = user.id,
                    FullName = user.firstName + " " +
                user.lastName,
                Date = user.date,
                };
                result.Users.Add(pVM);
            }
            result.Count = result.Users.Count;
            return result;

        }
        public ListUserForListVM GetEntriesFromToday()
        {
            var users = _userRepo.GetEntriesFromToday();
            ListUserForListVM result = new ListUserForListVM();
            result.Users = new List<UserForListVM>();
            foreach (var user in users)
            {
                // mapowanie obiektow
                var pVM = new UserForListVM()
                {
                    Id = user.id,
                    FullName = user.firstName + " " +
                user.lastName,
                    Date = user.date,
                };
                result.Users.Add(pVM);
            }
            result.Count = result.Users.Count;
            return result;
        }
        public void AddEntry(User user)
        {
            _userRepo.AddEntry(user);
        }
        public Admin GetUser(string userId)
        {
            return (Admin)_userRepo.GetUser(userId);
        }


    }
}
