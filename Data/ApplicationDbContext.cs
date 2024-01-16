using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Budgetoo.Models;

namespace Budgetoo.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Tip> Tips { get; set; }
        public DbSet<Goal> Goals {  get; set; }
        public DbSet<MonthlyDebt> monthlyDebts { get; set; }   
        public DbSet<MonthlyMandatoryExpense> monthlyMandatoryExpenses { get; set; }    
        public DbSet<MonthlyPersonalExpense> monthlyPersonalExpenses { get; set; }  
        public DbSet<FinancialResource> financialResources { get; set; }    

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tip>().ToTable("Tip");
			modelBuilder.Entity<Goal>().ToTable("Goal");
			modelBuilder.Entity<MonthlyDebt>().ToTable("MonthlyDebt");
            modelBuilder.Entity<FinancialResource>().ToTable("FinancialResource");
            modelBuilder.Entity<MonthlyMandatoryExpense>().ToTable("MonthlyMandatoryExpense");
            modelBuilder.Entity<MonthlyPersonalExpense>().ToTable("MonthlyPersonalExpense");
		}
    

    }
}