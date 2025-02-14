using BorrowingService.Models;
using BorrowingService.Repositories;

namespace BorrowingService.Services;

public class BorrowingsService() : IBorrowingsService
{
    private readonly IBorrowingRepository _borrowingRepository;
    
    public BorrowingsService(IBorrowingRepository borrowingRepository) : this()
    {
        _borrowingRepository = borrowingRepository;
    }
    
    public async Task<IEnumerable<Borrowing>> GetAllBorrowingsAsync()
    {
        return await _borrowingRepository.GetAllAsync();
    }

    public async Task<Borrowing?> GetBorrowingByIdAsync(int id)
    {
        return await _borrowingRepository.GetByIdAsync(id);
    }

    public async Task AddBorrowingAsync(Borrowing borrowing)
    {
        await _borrowingRepository.AddAsync(borrowing);
    }

    public async Task UpdateBorrowingAsync(Borrowing borrowing)
    {
        await _borrowingRepository.UpdateAsync(borrowing);
    }

    public async Task DeleteBorrowingAsync(int id)
    {
        var book = await _borrowingRepository.GetByIdAsync(id);
        if (book == null)
        {
            throw new Exception($"Borrowing with ID {id} does not exist.");
        }

        await _borrowingRepository.DeleteAsync(id);
    }
}