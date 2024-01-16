using Budgetoo.Data;
using Budgetoo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Budgetoo.Pages
{
    public class AddEnvelopesModel : PageModel
    {
        private readonly ApplicationDbContext _dbContext;
        public string successMessage = "";
        public string errorMessage = "";

        public AddEnvelopesModel(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        //[BindProperty]
        //public FinancialResource FinancialResourceRequest { get; set; }

        //[BindProperty]
        //public MonthlyMandatoryExpenseViewModel MonthlyMandatoryExpenseRequest { get; set; }

        [BindProperty]
        public MonthlyDebt MonthlyDebtRequest { get; set; }

        [BindProperty]
        public MonthlyPersonalExpense MonthlyPersonalExpenseRequest { get; set; }

        [BindProperty]
        public Goal GoalRequest { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Console.WriteLine("1111111111111111111111111111111111111111111111111111111111111111111111");
                    var Income = Request.Form["FinancialResource-Income"];
                    var SalaryDate = Request.Form["FinancialResource-SalaryDate"];
                    if (decimal.TryParse(Income, out decimal income) && DateTime.TryParse(SalaryDate, out DateTime salaryDate))
                    {
                        var FinancialResourceModel = new FinancialResource(income, salaryDate);
                        _dbContext.financialResources.Add(FinancialResourceModel);
                    }
                    else
                    {
                        throw new Exception("Cannot parse data!");
                    }
                    Console.WriteLine("222222222222222222222222222222222222222222222222222222222222222222222222222");
                    var Name = Request.Form["MonthlyMandatoryExpense-Name"];
                    var Amount = Request.Form["MonthlyMandatoryExpense-Amount"];
                    if (string.IsNullOrEmpty(Name) && decimal.TryParse(Amount, out decimal amount))
                    {
                        var MonthlyMandatoryExpenseModel = new MonthlyMandatoryExpense(Name, amount);
                        _dbContext.monthlyMandatoryExpenses.Add(MonthlyMandatoryExpenseModel);
                    }
                    else
                    {
                        throw new Exception("Cannot parse data!");
                    }
                    Console.WriteLine("3333333333333333333333333333333333333333333333333333333333333333333333333333");
                    var MonthlyDebtModel = new MonthlyDebt
                    {
                        Name = MonthlyDebtRequest.Name,
                        Amount = MonthlyDebtRequest.Amount,
                        DueTo = MonthlyDebtRequest.DueTo
                    };

                    var MonthlyPersonalExpenseModel = new MonthlyPersonalExpense
                    {
                        Amount = MonthlyPersonalExpenseRequest.Amount
                    };

                    var GoalModel = new Goal
                    {
                        Name = GoalRequest.Name,
                        Amount = GoalRequest.Amount,
                        DueTo = GoalRequest.DueTo
                    };

                    _dbContext.monthlyDebts.Add(MonthlyDebtModel);
                    _dbContext.monthlyPersonalExpenses.Add(MonthlyPersonalExpenseModel);
                    _dbContext.Goals.Add(GoalModel);
                    _dbContext.SaveChanges();

                    this.successMessage = "Your message has been received correctly!";
                }
                catch (Exception)
                {
                    Console.WriteLine("EEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE");
                }
            }
            else
            {
                this.errorMessage = "Data validation failed!";
            }
            return Page();
        }
    }
}
