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
using PS3.Interfaces;
using PS3.ViewModels.User;
using System.Security.Claims;

namespace PS3.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IUserService _userService;
        public ListUserForListVM Records { get; set; }
      
        [BindProperty]
        public User Person { get; set; }

        public IndexModel(ILogger<IndexModel> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
            
        }

        public void OnGet()
        {
            Records = _userService.GetEntriesFromToday();
        }
        public IActionResult OnPost()
        { - z
            var claimsIdentity = (ClaimsIdentity)User.Identity; //problemem sa prawdopodbnie te linijki - znalezienie i dodanie admina
            var claims = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            if (ModelState.IsValid)
            {
                Person.date = DateTime.Now;
                Person.admin = _userService.GetUser(claims.Value);
                _userService.AddEntry(Person);
                Records = _userService.GetEntriesFromToday();
               
            }
            return Page();
;        }

    }
}
