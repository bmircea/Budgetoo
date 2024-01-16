using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Budgetoo.Pages
{
    [Authorize]
    public class ReportsModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
