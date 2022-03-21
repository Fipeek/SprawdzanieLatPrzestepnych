using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using PS3.Models;
namespace PS3.Pages
{
    public class ZapisaneModel : PageModel
    {
        public UserDataHolder UserDataHolder { get; set; }    
        public void OnGet()
        {
             
            var Data = HttpContext.Session.GetString("Data");
            if (Data != null)
                UserDataHolder =
                JsonConvert.DeserializeObject<UserDataHolder>(Data);
        }
        public string checkYear(int? year)
        {
            if(year == null)
            {
                return "";
            }
            if(year%100==0 && year % 400 == 0)
            {
                return "przestêpny";
            }
            if (year % 4 == 0)
            {
                return "przestêpny";
            }
            return "nieprzestêpny";
        }
    }
}
