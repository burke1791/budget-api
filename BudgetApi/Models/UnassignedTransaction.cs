using System;
using System.ComponentModel.DataAnnotations;

namespace BudgetApi.Models {
  public class UnassignedTransaction {
    [Key]
    public Int32 AccountId { get; set; }
    public String AccountName { get; set; }
    public String AccountType { get; set; }
    public Int32 UnassignedTransactions { get; set; }
  }
}