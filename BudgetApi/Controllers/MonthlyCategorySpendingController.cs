using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BudgetApi.Models;

namespace BudgetApi.Controllers {
  [Route("api/[controller]")]
  [ApiController]
  public class CategorySpendingController : ControllerBase {
    private readonly BudgetContext _context;

    public CategorySpendingController(BudgetContext context) {
      _context = context;
    }

    // GET: api/CategorySpending/{month}
    [HttpGet("{month}")]
    public async Task<ActionResult<IEnumerable<MonthlyCategorySpending>>> GetCategorySpending(DateTime month) {
      var categorySpending = await _context.MonthlyCategorySpendings.Where(e => e.Month == month).ToListAsync();

      if (categorySpending == null) {
        return NotFound();
      }

      return categorySpending;
    }

    private bool CategorySpendingExists(DateTime month) {
      return _context.MonthlyCategorySpendings.Any(e => e.Month == month);
    }
  }
}