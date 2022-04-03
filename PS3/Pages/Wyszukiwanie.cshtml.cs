using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PS3.Data;
using PS3.Models;

namespace PS3.Pages
{
    public class WyszukiwanieModel : PageModel
    {
       
        private readonly UsersContext _context;
        [BindProperty]
        public User User { get; set; }
        public IList<User> Users { get; set; }

        public WyszukiwanieModel(UsersContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
            Users = _context.User.ToList();
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                Users = _context.User.Where(p=> p.firstName == User.firstName).ToList();
            }
            return Page();
        }
    }
}
