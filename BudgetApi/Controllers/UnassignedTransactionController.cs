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
  public class UnassignedTransactionController : ControllerBase {
    private readonly BudgetContext _context;

    public UnassignedTransactionController(BudgetContext context) {
      _context = context;
    }

    // GET: api/UnassignedTransaction
    [HttpGet]
    public async Task<ActionResult<IEnumerable<UnassignedTransaction>>> GetUnassignedTransactions() {
      return await _context.UnassignedTransactions.OrderBy(t => t.AccountId).ToListAsync();
    }

    // GET: api/UnassignedTransaction/1
    [HttpGet("{accountId}")]
    public async Task<ActionResult<UnassignedTransaction>> GetUnassignedTransaction(Int32 accountId) {
      var unassignedTransaction = await _context.UnassignedTransactions.FindAsync(accountId);

      if (unassignedTransaction == null) {
        return NotFound();
      }

      return unassignedTransaction;
    }

    private bool UnassignedTransactionExists(Int32 accountId) {
      return _context.UnassignedTransactions.Any(t => t.AccountId == accountId);
    }
  }
}