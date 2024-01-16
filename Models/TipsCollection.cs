using Budgetoo.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Budgetoo.Models
{
    public class TipsCollection
    {
        public readonly ApplicationDbContext _context;
        [BindProperty]
        public List<Tip> Tips { get; set; } = default!;
        public TipsCollection()
        {
        }
        public Tip GetTipOfTheDay()
        {
            GetTips();

            return Tips[0];

        }

        public async void GetTips()
        {
            Tips = await _context.Tips.ToListAsync();

        }
    }
}
