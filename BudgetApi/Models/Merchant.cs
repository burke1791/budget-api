using System;
using System.ComponentModel.DataAnnotations;

namespace BudgetApi.Models {
  public class Merchant {
    [Key]
    public Int32 MerchantId { get; set; }
    public String MerchantName { get; set; }
    public Int32 DefaultCategoryId { get; set; }
  }
}