using System;
using Microsoft.EntityFrameworkCore;

namespace BudgetApi.Models {
  [Keyless]
  public class MonthlyCategorySpending {
    public DateTime Month { get; set; }
    public Int32 CategoryGroupId { get; set; }
    public String CategoryGroupName { get; set; }
    public Int32 CategoryId { get; set; }
    public String CategoryName { get; set; }
    public System.Nullable<Int16> DisplayOrder { get; set; }
    public System.Nullable<Decimal> Spent { get; set; }
  }
}