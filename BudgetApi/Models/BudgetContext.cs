using Microsoft.EntityFrameworkCore;
using BudgetApi.Models;

namespace BudgetApi.Models {
  public class BudgetContext : DbContext {
    public BudgetContext(DbContextOptions<BudgetContext> options) : base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
      modelBuilder.Entity<Transaction>().ToTable("Transactions");
      modelBuilder.Entity<CashFlow>().ToView("MonthlyCashFlow");
      modelBuilder.Entity<Account>().ToView("AccountMetaData");
      modelBuilder.Entity<Category>().ToView("BudgetCategories");
    }

    public DbSet<Transaction> Transactions { get; set; }
    public DbSet<CashFlow> CashFlows { get; set; }
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Category> Categories { get; set; }
  }
}