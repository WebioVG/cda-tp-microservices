using BorrowingService.Data;
using BorrowingService.Models;
using Microsoft.EntityFrameworkCore;

namespace BorrowingService.Repositories;

public class BorrowingRepository(BorrowingContext context) : IBorrowingRepository
{
    public async Task<IEnumerable<Borrowing>> GetAllAsync() =>
        await context.Borrowings.ToListAsync();

    public async Task<Borrowing?> GetByIdAsync(int id) =>
        await context.Borrowings.FindAsync(id);

    public async Task AddAsync(Borrowing borrowing)
    {
        await context.Borrowings.AddAsync(borrowing);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Borrowing borrowing)
    {
        context.Borrowings.Update(borrowing);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var borrowing = await context.Borrowings.FindAsync(id);
        if (borrowing != null)
        {
            context.Borrowings.Remove(borrowing);
            await context.SaveChangesAsync();
        }
    }
}