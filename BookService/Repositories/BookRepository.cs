using BookService.Data;
using BookService.Models;
using Microsoft.EntityFrameworkCore;

namespace BookService.Repositories;

public class BookRepository(BookContext context) : IBookRepository
{
    public async Task<IEnumerable<Book>> GetAllAsync() =>
        await context.Books.ToListAsync();

    public async Task<IEnumerable<Book>> GetAllByTitleAsync(string title)
    {
        return await context.Books.Where(b => b.Title.Contains(title)).ToListAsync();
    }

    public async Task<Book?> GetByIdAsync(int id) =>
        await context.Books.FindAsync(id);

    public async Task AddAsync(Book book)
    {
        await context.Books.AddAsync(book);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Book book)
    {
        context.Books.Update(book);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var book = await context.Books.FindAsync(id);
        if (book != null)
        {
            context.Books.Remove(book);
            await context.SaveChangesAsync();
        }
    }
}