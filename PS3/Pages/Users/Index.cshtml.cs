#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PS3.Data;
using PS3.Models;

namespace PS3.Pages.Users
{
    public class IndexModel : PageModel
    {
        private readonly PS3.Data.UsersContext _context;

        public IndexModel(PS3.Data.UsersContext context)
        {
            _context = context;
        }

        public IList<User> User { get;set; }
       
        public async Task OnGetAsync()
        {
            User = await _context.User.OrderByDescending(s => s.date).Take(20).ToListAsync();
            
        }
    }
}
