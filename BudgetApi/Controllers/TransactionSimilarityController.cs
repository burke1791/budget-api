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
  public class TransactionSimilarityController : ControllerBase {
    private readonly BudgetContext _context;

    public TransactionSimilarityController(BudgetContext context) {
      _context = context;
    }

    // GET: api/TransactionSimilarity/5
    [HttpGet("{transactionId}")]
    public async Task<ActionResult<IEnumerable<TransactionSimilarity>>> GetTransactionSimilarities(Int64 transactionId) {
      string sql = "Exec dbo.up_GetSimilarTransactions @TransactionId = @TransactionId";
      SqlParameter pTransactionId = new SqlParameter("TransactionId", transactionId);

      return await _context.TransactionSimilarities.FromSqlRaw<TransactionSimilarity>(sql, pTransactionId).ToListAsync();
    }
  }
}