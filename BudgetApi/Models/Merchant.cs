using System;
using System.ComponentModel.DataAnnotations;

namespace BudgetApi.Models {
  public class Merchant {
    [Key]
    public Int32 MerchantId { get; set; }
    public String MerchantName { get; set; }
    public Int32 DefaultCategoryId { get; set; }
  }

  public class MerchantSearch {
    [Key]
    public Int32 MerchantId { get; set; }
    public String SearchString { get; set; }
    public String NotLike { get; set; }
    public System.Nullable<Int32> AccountId { get; set; }
  }
}