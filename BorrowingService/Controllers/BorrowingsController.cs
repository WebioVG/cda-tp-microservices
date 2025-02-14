using BorrowingService.Models;
using BorrowingService.Services;
using Microsoft.AspNetCore.Mvc;

namespace BorrowingService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BorrowingsController(IBorrowingsService borrowingsService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<Borrowing>> GetAllBorrowingsAsync()
    {
        var books = await borrowingsService.GetAllBorrowingsAsync();
        return Ok(books);
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<Borrowing>> GetBorrowing(int id)
    {
        var book = await borrowingsService.GetBorrowingByIdAsync(id);
        if (book == null) return NotFound();
        return Ok(book);
    }
    
    [HttpPost]
    public async Task<ActionResult> CreateBorrowing(Borrowing borrowing)
    {
        await borrowingsService.AddBorrowingAsync(borrowing);
        return CreatedAtAction(nameof(GetBorrowing), new { id = borrowing.Id }, borrowing);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateBorrowing(int id, Borrowing borrowing)
    {
        if (id != borrowing.Id) return BadRequest();
        await borrowingsService.UpdateBorrowingAsync(borrowing);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteBorrowing(int id)
    {
        await borrowingsService.DeleteBorrowingAsync(id);
        return NoContent();
    }
}