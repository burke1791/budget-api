using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using Microsoft.EntityFrameworkCore;
using BudgetApi.Models;

namespace BudgetApi.Controllers {
  [Route("api/[controller]")]
  [ApiController]
  public class CashFlowController : ControllerBase {
    private readonly BudgetContext _context;

    public CashFlowController(BudgetContext context) {
      _context = context;
    }

    // GET: api/CashFlow
    [EnableCors]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CashFlow>>> GetCashFlows() {
      return  await _context.CashFlows.OrderByDescending(p => p.TransactionMonth).ToListAsync();
    }

    // GET: api/CashFlow/5
    [EnableCors]
    [HttpGet("{month}")]
    public async Task<ActionResult<CashFlow>> GetCashFlow(DateTime month) {
      var cashFlow = await _context.CashFlows.FindAsync(month);

      if (cashFlow == null) {
        return NotFound();
      }

      return cashFlow;
    }

    private bool CashFlowExists(DateTime id) {
      return _context.CashFlows.Any(e => e.TransactionMonth == id);
    }
  }
}
