using System;
using System.ComponentModel.DataAnnotations;

namespace BudgetApi.Models {
  public class Transaction {
    public Int64 TransactionId { get; set; }
    public DateTime TransactionDate { get; set; }
    public Int32 AccountId { get; set; }
    public System.Nullable<Int32> MerchantId { get; set; }
    public Decimal Amount { get; set; }
    public Int32 RawTransactionId { get; set; }
    public System.Nullable<Int32> UserSelectedCategoryId { get; set; }
  }

  public class CategorizeTransaction {
    [Key]
    public Int64 TransactionId { get; set; }
    public Int32 CategoryId { get; set; }
    public String IncludedTransactions { get; set; }
  }
}