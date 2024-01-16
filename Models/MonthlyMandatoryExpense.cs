using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Budgetoo.Models
{
	public class MonthlyMandatoryExpense
	{
		[Key]
		public Guid Id { get; set; }

		[Required]
		[StringLength(60, MinimumLength = 3)]
		public string Name { get; set; }

		[Required]
		[Column(TypeName = "decimal(11, 2)")]
		public decimal Amount { get; set; }

		public MonthlyMandatoryExpense() { }

		public MonthlyMandatoryExpense(string _Name, decimal _Amount)
		{
			this.Name = _Name;
			this.Amount = _Amount;
		}
	}
}
