using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace BudgetApi.Models {
  [Keyless]
  public class RowCount {
    public int Count { get; set; }

    public override string ToString() {
      return Count.ToString();
    }
  }
}