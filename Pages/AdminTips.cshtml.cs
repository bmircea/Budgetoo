using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using Budgetoo.Models;
using Microsoft.EntityFrameworkCore;

namespace Budgetoo.Pages
{
    [Authorize]
    public class AdminTipsModel : PageModel
    {
        public bool IsAdmin => HttpContext.User.HasClaim("IsAdmin", bool.TrueString);
        public readonly Budgetoo.Data.ApplicationDbContext _context;
        [BindProperty]
        public Tip NewTip { get; set; } = default!;
		public IList<Tip> Tips { get; set; } = default!;
		public AdminTipsModel(Budgetoo.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        

        public async Task<IActionResult> OnGetAsync()
        {
            if (_context.Tips != null)
            {
                Tips = await _context.Tips.ToListAsync();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Tips.Add(NewTip);

            await _context.SaveChangesAsync();

			return RedirectToAction("Get");
		}

        public async Task<IActionResult> OnPostDelete(int id)
        {
            if (_context.Tips != null)
            {
                var tip = await _context.Tips.FindAsync(id);
                if (tip != null)
                {
                    _context.Tips.Remove(tip);
			        await _context.SaveChangesAsync();

				}
			}
			return RedirectToAction("Get");
        }
    }
}
