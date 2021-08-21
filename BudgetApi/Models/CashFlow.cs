using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BudgetApi.Models {
  // [Keyless]
  public class CashFlow {
    [Key]
    public DateTime TransactionMonth { get; set; }
    public Decimal CashFlowIn { get; set; }
    public Decimal CashFlowOut { get; set; }
    public Int32 UnassignedTransactionCount { get; set; }
  }
}