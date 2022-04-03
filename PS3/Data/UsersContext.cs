using PS3.Models;
using Microsoft.EntityFrameworkCore;
namespace PS3.Data
{
    public class UsersContext :  DbContext   
    {
      
        public UsersContext(DbContextOptions options) : base(options) { }
        public DbSet<User> User { get; set; }
    }
}
