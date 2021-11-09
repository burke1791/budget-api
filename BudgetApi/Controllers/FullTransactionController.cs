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
  public class FullTransactionController : ControllerBase {
    private readonly BudgetContext _context;

    public FullTransactionController(BudgetContext context) {
      _context = context;
    }

    // GET: api/FullTransaction
    [HttpGet]
    public async Task<ActionResult<IEnumerable<FullTransaction>>> GetFullTransactions() {
      return await _context.FullTransactions.OrderByDescending(t => t.TransactionId).ToListAsync();
    }
  }
}