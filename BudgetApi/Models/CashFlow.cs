using System;
using System.ComponentModel.DataAnnotations;

namespace BudgetApi.Models {
  public class CashFlow {
    [Key]
    public DateTime TransactionMonth { get; set; }
    public Decimal CashFlowIn { get; set; }
    public Decimal CashFlowOut { get; set; }
    public Int32 UnassignedTransactionCount { get; set; }
  }
}