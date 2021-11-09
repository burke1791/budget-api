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
      return await _context.FullTransactions.OrderByDescending(t => t.TransactionDate).ToListAsync();
    }

    // GET: api/FullTransaction/id/123
    [HttpGet("id/{transactionId}")]
    public async Task<ActionResult<FullTransaction>> GetTransaction(Int64 transactionId) {
      var fullTransaction = await _context.FullTransactions.FindAsync(transactionId);

      if (fullTransaction == null) {
        return NotFound();
      }

      return fullTransaction;
    }

    // GET: api/FullTransaction/month/2021-10
    [HttpGet("month/{month}")]
    public async Task<ActionResult<IEnumerable<FullTransaction>>> GetTransactionsFromMonth(DateTime month) {
      var fullTransactions = await _context.FullTransactions
        .Where(t => t.TransactionDate >= month && t.TransactionDate < month.AddMonths(1))
        .OrderByDescending(t => t.TransactionDate)
        .ToListAsync();

      if (fullTransactions == null) {
        return NotFound();
      }

      return fullTransactions;
    }

    private bool FullTransactionExists(Int64 transactionId) {
      return _context.FullTransactions.Any(t => t.TransactionId == transactionId);
    }
  }
}