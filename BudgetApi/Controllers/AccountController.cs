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
  public class AccountController : ControllerBase {
    private readonly BudgetContext _context;

    public AccountController(BudgetContext context) {
      _context = context;
    }

    // GET: api/Account
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Account>>> GetAccounts() {
      return await _context.Accounts.ToListAsync();
    }

    // GET: api/Account/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Account>> GetAccount(int id) {
      var account = await _context.Accounts.FindAsync(id);

      if (account == null) {
        return NotFound();
      }

      return account;
    }

    // POST: api/Account
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Account>> PostAccount(Account account) {
      _context.Accounts.Add(account);
      try {
        await _context.SaveChangesAsync();
      } catch (DbUpdateException) {
        if (AccountExists(account.AccountId)) {
          return Conflict();
        } else {
          throw;
        }
      }

      return CreatedAtAction("GetAccount", new { id = account.AccountId }, account);
    }

    // TODO: update a DeletedDate column in the table instead of deleting the record
    // DELETE: api/Account/5
    // [HttpDelete("{id}")]
    // public async Task<IActionResult> DeleteAccount(int id) {
    //   var account = await _context.Accounts.FindAsync(id);
    //   if (account == null) {
    //     return NotFound();
    //   }

    //   _context.Accounts.Remove(account);
    //   await _context.SaveChangesAsync();

    //   return NoContent();
    // }

    private bool AccountExists(int id) {
      return _context.Accounts.Any(e => e.AccountId == id);
    }
  }
}
