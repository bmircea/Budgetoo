using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Budgetoo.Models
{
	public class MonthlyPersonalExpense
	{
		[Key]
		public Guid Id { get; set; }

		[Required]
		[Column(TypeName = "decimal(11, 2)")]
		public decimal Amount { get; set; }
	}
}
