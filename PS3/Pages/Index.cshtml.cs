using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PS3.Models;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Collections;
using System.Web;
using Microsoft.AspNetCore.Session;
using PS3.Data;

namespace PS3.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly UsersContext _context;
        public IList<User> Users { get; set; }
        [BindProperty]
        public UsersInSession UsersInSession { get; set; }  
        [BindProperty]
        public User User { get; set; }

        public IndexModel(ILogger<IndexModel> logger, UsersContext context)
        {
            _logger = logger;
            _context = context;
        }

        public void OnGet()
        {
          
            var Data2 = HttpContext.Session.GetString("Data2");
            if (Data2 != null)
                UsersInSession =
                JsonConvert.DeserializeObject<UsersInSession>(Data2);
            Users = _context.User.ToList();
        }
        public IActionResult OnPost()
        {
           
            var Data2 = HttpContext.Session.GetString("Data2");
            if (Data2 != null)
                UsersInSession =
                JsonConvert.DeserializeObject<UsersInSession>(Data2);
            if (ModelState.IsValid)
            {
                User.date = DateTime.Now;
                UsersInSession.Users.Add(User);
                _context.User.Add(User);
               
            }
              _context.SaveChanges();
            Users = _context.User.ToList();
            HttpContext.Session.SetString("Data2",
               JsonConvert.SerializeObject(UsersInSession));
            return Page();
;        }

    }
}