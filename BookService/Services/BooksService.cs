using BookService.Models;
using BookService.Repositories;

namespace BookService.Services;

public class BooksService() : IBooksService
{
    private readonly IBookRepository _bookRepository;
    
    public BooksService(IBookRepository bookRepository) : this()
    {
        _bookRepository = bookRepository;
    }
    
    public async Task<IEnumerable<Book>> GetAllBooksAsync()
    {
        return await _bookRepository.GetAllAsync();
    }

    public async Task<Book?> GetBookByIdAsync(int id)
    {
        return await _bookRepository.GetByIdAsync(id);
    }

    public async Task AddBookAsync(Book book)
    {
        await _bookRepository.AddAsync(book);
    }

    public async Task UpdateBookAsync(Book book)
    {
        await _bookRepository.UpdateAsync(book);
    }

    public async Task DeleteBookAsync(int id)
    {
        var book = await _bookRepository.GetByIdAsync(id);
        if (book == null)
        {
            throw new Exception($"Book with ID {id} does not exist.");
        }

        await _bookRepository.DeleteAsync(id);
    }
}