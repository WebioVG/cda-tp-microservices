using UserService.Models;

namespace UserService.Repositories;

public interface IUserRepository
{
    Task<IEnumerable<User>> GetAllAsync();
    Task<User?> GetByIdAsync(int id);
    Task AddAsync(User customer);
    Task UpdateAsync(User customer);
    Task DeleteAsync(int id);
}