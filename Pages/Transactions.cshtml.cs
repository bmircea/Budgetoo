using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Budgetoo.Pages
{
    [Authorize]
    public class Index1Model : PageModel
    {
        public void OnGet()
        {
        }
    }
}
