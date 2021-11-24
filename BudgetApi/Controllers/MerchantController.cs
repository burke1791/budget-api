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
  public class MerchantController : ControllerBase {
    private readonly BudgetContext _context;

    public MerchantController(BudgetContext context) {
      _context = context;
    }

    // GET: api/Merchant
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Merchant>>> GetMerchants() {
      return await _context.Merchants.OrderBy(m => m.MerchantName).ToListAsync();
    }

    // GET: api/Merchant/5
    [HttpGet("{merchantId}")]
    public async Task<ActionResult<Merchant>> GetMerchant(int merchantId) {
      var merchant = await _context.Merchants.FindAsync(merchantId);

      if (merchant == null) {
        return NotFound();
      }

      return merchant;
    }

    // POST: api/Merchant
    [HttpPost]
    public async Task<ActionResult<Merchant>> NewMerchant(Merchant merchant) {
      _context.Merchants.Add(merchant);
      try {
        await _context.SaveChangesAsync();
      } catch (DbUpdateException) {
        if (MerchantExists(merchant.MerchantId)) {
          return Conflict();
        } else {
          throw;
        }
      }

      return CreatedAtAction("GetMerchant", new { merchantId = merchant.MerchantId }, merchant);
    }

    private bool MerchantExists(int merchantId) {
      return _context.Merchants.Any(m => m.MerchantId == merchantId);
    }
  }
}