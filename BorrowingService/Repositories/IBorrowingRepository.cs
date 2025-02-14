using BorrowingService.Models;

namespace BorrowingService.Repositories;

public interface IBorrowingRepository
{
    Task<IEnumerable<Borrowing>> GetAllAsync();
    Task<Borrowing?> GetByIdAsync(int id);
    Task AddAsync(Borrowing borrowing);
    Task UpdateAsync(Borrowing borrowing);
    Task DeleteAsync(int id);
}