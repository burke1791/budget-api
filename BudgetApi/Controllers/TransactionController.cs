using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using BudgetApi.Models;

namespace BudgetApi.Controllers {
  [Route("api/[controller]")]
  [ApiController]
  public class TransactionController : ControllerBase {
    private readonly BudgetContext _context;

    public TransactionController(BudgetContext context) {
      _context = context;
    }

    // GET: api/Transaction
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Transaction>>> GetTransactions() {
      return await _context.Transactions.ToListAsync();
    }

    // GET: api/Transaction/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Transaction>> GetTransaction(long id) {
      var transaction = await _context.Transactions.FindAsync(id);

      if (transaction == null) {
        return NotFound();
      }

      return transaction;
    }

    // PUT: api/Transaction/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    // [HttpPut("{id}")]
    // public async Task<IActionResult> PutTransaction(long id, Transaction transaction) {
    //   if (id != transaction.TransactionId) {
    //     return BadRequest();
    //   }

    //   _context.Entry(transaction).State = EntityState.Modified;

    //   try {
    //     await _context.SaveChangesAsync();
    //   } catch (DbUpdateConcurrencyException) {
    //     if (!TransactionExists(id)) {
    //       return NotFound();
    //     } else {
    //       throw;
    //     }
    //   }

    //   return NoContent();
    // }

    // POST: api/Transaction/category
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost("category")]
    public async Task<ActionResult<IEnumerable<RowCount>>> PostTransaction([FromBody] CategorizeTransaction transaction) {
      string sql = "Exec dbo.up_CategorizeTransaction @TransactionId = @TransactionId, @CategoryId = @CategoryId, @IncludedTransactionIds = @IncludedTransactionIds";
      
      var parms = new List<SqlParameter> {
        new SqlParameter("TransactionId", transaction.TransactionId),
        new SqlParameter("CategoryId", transaction.CategoryId),
        new SqlParameter("IncludedTransactionIds", transaction.IncludedTransactions)
      };
      
      return await _context.RowCounts.FromSqlRaw(sql, parms.ToArray()).ToListAsync();
    }

    // DELETE: api/Transaction/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTransaction(long id) {
      var transaction = await _context.Transactions.FindAsync(id);
      if (transaction == null) {
        return NotFound();
      }

      _context.Transactions.Remove(transaction);
      await _context.SaveChangesAsync();

      return NoContent();
    }

    private bool TransactionExists(long id) {
      return _context.Transactions.Any(e => e.TransactionId == id);
    }
  }
}
