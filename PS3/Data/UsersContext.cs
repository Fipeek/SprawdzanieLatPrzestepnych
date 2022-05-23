using PS3.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
namespace PS3.Data
{
    public class UsersContext :  IdentityDbContext   
    {
      
        public UsersContext(DbContextOptions<UsersContext> options) : base(options) { }
        public DbSet<User> User { get; set; }
    }
}
