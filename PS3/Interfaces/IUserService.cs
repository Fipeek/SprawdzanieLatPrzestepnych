using PS3.Models;
using PS3.ViewModels.User;

namespace PS3.Interfaces
{
    public interface IUserService
    {
        ListUserForListVM GetUsersForList();
        void AddEntry(User user);
        ListUserForListVM GetEntriesFromToday();
    }
}
