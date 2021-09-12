using System;
using System.ComponentModel.DataAnnotations;

namespace BudgetApi.Models {
  public class Category {
    [Key]
    public Int32 CategoryId { get; set; }
    public String CategoryName { get; set; }
    public Int32 CategoryGroupId { get; set; }
    public String CategoryGroupName { get; set; }
    public Boolean IsIgnoredForCashFlow { get; set; }
    public System.Nullable<Int16> DisplayOrder { get; set; }
  }
}