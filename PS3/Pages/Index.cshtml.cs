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

namespace PS3.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IUserService _userService;
        public ListUserForListVM Records { get; set; }
      
        [BindProperty]
        public User User { get; set; }

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
        {
                     
            if (ModelState.IsValid)
            {
                User.date = DateTime.Now;

                _userService.AddEntry(User);
                Records = _userService.GetEntriesFromToday();
               
            }
            return Page();
;        }

    }
}