using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using PS3.Models;
namespace PS3.Pages
{
    public class ZapisaneModel : PageModel
    {
        public User User { get; set; }
        public UsersInSession UsersInSession {get; set;}
      
        
        public void OnGet()
        {
            var Data2 = HttpContext.Session.GetString("Data2");
            if (Data2 != null)
                UsersInSession =
                JsonConvert.DeserializeObject<UsersInSession>(Data2);

            HttpContext.Session.SetString("Data2",
               JsonConvert.SerializeObject(UsersInSession));






        }
        
    }
}
