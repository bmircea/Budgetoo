using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Budgetoo.Models
{
	public class FinancialResource
	{
		[Key]
		public Guid Id { get; set; }

		[Required(ErrorMessage = "Income is a mandatory field.")]
		[Column(TypeName = "decimal(11, 2)")]
		public decimal Income { get; set; }

		[Required]
		[DataType(DataType.Date)]
		public DateTime SalaryDate { get; set; }

		public FinancialResource() { }
		public FinancialResource(decimal _Income, DateTime _SalaryDate)
		{
			this.Income = _Income;
			this.SalaryDate = _SalaryDate;
		}
	}
}
