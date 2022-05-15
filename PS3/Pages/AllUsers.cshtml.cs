using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PS3.Interfaces;
using PS3.Models;
using PS3.ViewModels.User;

namespace PS3.Pages
{
    public class AllUsersModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IUserService _userService;
        public ListUserForListVM Records { get; set; }

        [BindProperty]
        public User User { get; set; }

        public AllUsersModel(ILogger<IndexModel> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;

        }
        public void OnGet()
        {
            Records = _userService.GetUsersForList();

        }
    }
}
