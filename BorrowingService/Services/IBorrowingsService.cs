using BorrowingService.Models;

namespace BorrowingService.Services;

public interface IBorrowingsService
{
    Task<IEnumerable<Borrowing>> GetAllBorrowingsAsync();
    Task<Borrowing?> GetBorrowingByIdAsync(int id);
    Task AddBorrowingAsync(Borrowing borrowing);
    Task UpdateBorrowingAsync(Borrowing borrowing);
    Task DeleteBorrowingAsync(int id);
}