using PS3.Data;
using PS3.Interfaces;
using PS3.Models;

namespace PS3.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UsersContext _context;

        public UserRepository(UsersContext context)
        {
            _context = context;
        }
        public IQueryable<User> GetAllUsers()
        {
            return _context.User;
        }
        public void AddEntry(User user)
        {
            _context.User.Add(user);
            _context.SaveChanges(); 
        }
        public IQueryable<User> GetEntriesFromToday()
        {
            return _context.User.Where(p=> p.date == DateTime.Today);
        }

       
    }
}
