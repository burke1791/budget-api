using System;
using System.ComponentModel.DataAnnotations;

namespace BudgetApi.Models {
  public class Account {
    [Key]
    public Int32 AccountId { get; set; }
    public String AccountType { get; set; }
    public String AccountName { get; set; }
  }
}