using BookService.Data;
using BookService.Models;
using Microsoft.EntityFrameworkCore;

namespace BookService.Repositories;

public class BookRepository(BookContext context) : IBookRepository
{
    public async Task<IEnumerable<Book>> GetAllAsync() =>
        await context.Users.ToListAsync();

    public async Task<Book?> GetByIdAsync(int id) =>
        await context.Users.FindAsync(id);

    public async Task AddAsync(Book book)
    {
        await context.Users.AddAsync(book);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Book book)
    {
        context.Users.Update(book);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var book = await context.Users.FindAsync(id);
        if (book != null)
        {
            context.Users.Remove(book);
            await context.SaveChangesAsync();
        }
    }
}