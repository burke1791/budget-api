using Microsoft.EntityFrameworkCore;

namespace BudgetApi.Models {
  public class BudgetContext : DbContext {
    public BudgetContext(DbContextOptions<BudgetContext> options) : base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
      modelBuilder.Entity<Transaction>().ToTable("Transactions");
      modelBuilder.Entity<CashFlow>().ToView("MonthlyCashFlow");
    }

    public DbSet<Transaction> Transactions { get; set; }
    public DbSet<CashFlow> CashFlows { get; set; }
  }
}