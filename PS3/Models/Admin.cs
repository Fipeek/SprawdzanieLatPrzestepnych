using Microsoft.AspNetCore.Identity;
namespace PS3.Models
{
    public class Admin : IdentityUser
    {
        public List<User>? Users { get; set; }

    }
}
