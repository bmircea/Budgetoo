using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Budgetoo.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        [BindProperty]
        public string currentTab { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            currentTab = "_Tab1";
        }

        public void OnGet()
        {

        }
    }
}