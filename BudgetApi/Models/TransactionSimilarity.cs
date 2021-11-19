using System;
using System.ComponentModel.DataAnnotations;

namespace BudgetApi.Models {
  public class TransactionSimilarity {
    [Key]
    public Int64 TransactionId { get; set; }
    public DateTime TransactionDate { get; set; }
    public Int32 AccountId { get; set; }
    public String AccountName { get; set; }
    public String AccountType { get; set; }
    public System.Nullable<Int32> MerchantId { get; set; }
    public String MerchantName { get; set; }
    public System.Nullable<Int32> CategoryId { get; set; }
    public String CategoryName { get; set; }
    public System.Nullable<Int32> CategoryGroupId { get; set; }
    public String CategoryGroupName { get; set; }
    public Decimal Amount { get; set; }
    public String Description { get; set; }
    public bool IsUncategorized { get; set; }
    
    public Decimal SimilarityScore { get; set; }
  }
}