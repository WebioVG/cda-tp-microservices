using BookService.Models;
using BookService.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BooksController(IBooksService booksService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<Book>> GetAllBooksAsync()
    {
        var books = await booksService.GetAllBooksAsync();
        return Ok(books);
    }

    [HttpGet("search")]
    public async Task<ActionResult<Book>> GetAllBooksByTitleAsync(string title)
    {
        var books = await booksService.GetAllBooksByTitleAsync(title);
        return Ok(books);
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<Book>> GetBook(int id)
    {
        var book = await booksService.GetBookByIdAsync(id);
        if (book == null) return NotFound();
        return Ok(book);
    }
    
    [HttpPost]
    public async Task<ActionResult> CreateBook(Book book)
    {
        await booksService.AddBookAsync(book);
        return CreatedAtAction(nameof(GetBook), new { id = book.Id }, book);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateBook(int id, Book book)
    {
        if (id != book.Id) return BadRequest();
        await booksService.UpdateBookAsync(book);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteBook(int id)
    {
        await booksService.DeleteBookAsync(id);
        return NoContent();
    }
}