using PS3.Models;

namespace PS3.Interfaces
{
    public interface IUserRepository
    {
        IQueryable<User> GetAllUsers();
        void AddEntry(User user);
        IQueryable<User> GetEntriesFromToday();
    }
}
