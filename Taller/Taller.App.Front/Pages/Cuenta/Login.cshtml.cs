using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Taller.App.Front.Pages
{
    public class LoginModel : PageModel
    {

        public string tituLogin { get; set; }

        public void OnGet()
        {
            tituLogin = $" Server time is {DateTime.Now}";
        }
    }
}
