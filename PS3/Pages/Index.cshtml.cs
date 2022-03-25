using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PS3.Models;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Collections;
using System.Web;
using Microsoft.AspNetCore.Session;
namespace PS3.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        
        [BindProperty]
        public UserDataHolder UserDataHolder { get; set; }
        public List<UserDataHolder> uzytkownicy2 { get; set; }
        public Users Users = new Users();
      

              
        
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
           
        }

        public void OnGet()
        {
            var Data2 = HttpContext.Session.GetString("Data2");
            if (Data2 != null)
                Users =
                JsonConvert.DeserializeObject<Users>(Data2);

        }
        public IActionResult OnPost()
        {
            var Data2 = HttpContext.Session.GetString("Data2");
            if (Data2 != null)
                Users =
                JsonConvert.DeserializeObject<Users>(Data2);
            if (ModelState.IsValid)
            {
                

                Users.uzytkownicy.Add(UserDataHolder);
                

                HttpContext.Session.SetString("Data2",
                JsonConvert.SerializeObject(Users));

            }
            //return RedirectToPage("./Zapisane");
            return Page();
;        }

    }
}