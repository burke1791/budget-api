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
  public class CategoryController : ControllerBase {
    private readonly BudgetContext _context;

    public CategoryController(BudgetContext context) {
      _context = context;
    }

    // GET: api/Category
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Category>>> GetCategories() {
      return await _context.Categories.ToListAsync();
    }

    // GET: api/Category/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Category>> GetCategory(int id) {
      var category = await _context.Categories.FindAsync(id);

      if (category == null) {
        return NotFound();
      }

      return category;
    }

    // POST: api/Category
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Category>> PostCategory(Category category) {
      _context.Categories.Add(category);
      try {
        await _context.SaveChangesAsync();
      } catch (DbUpdateException) {
        if (CategoryExists(category.CategoryId)) {
          return Conflict();
        } else {
          throw;
        }
      }

      return CreatedAtAction("GetCategory", new { id = category.CategoryId }, category);
    }

    // TODO: update a DeletedDate column in the table instead of deleting the record
    // DELETE: api/Category/5
    // [HttpDelete("{id}")]
    // public async Task<IActionResult> DeleteCategory(int id) {
    //   var category = await _context.Categories.FindAsync(id);
    //   if (category == null) {
    //     return NotFound();
    //   }

    //   _context.Categories.Remove(category);
    //   await _context.SaveChangesAsync();

    //   return NoContent();
    // }

    private bool CategoryExists(int id) {
      return _context.Categories.Any(e => e.CategoryId == id);
    }
  }
}
