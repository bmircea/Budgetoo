using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Budgetoo.Areas.Identity.Data;

// Add profile data for application users by adding properties to the BudgetooUser class
public class BudgetooUser : IdentityUser
{
    [Required]
    [MaxLength(100)]
    public string FirstName { get; set; } = string.Empty;


    [Required]
    [MaxLength(100)]
    public string LastName { get; set; } = string.Empty;
}

