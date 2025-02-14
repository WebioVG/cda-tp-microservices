using UserService.Models;

namespace UserService.Services;

public interface IUsersService
{
    Task<IEnumerable<User>> GetAllUsersAsync();
    Task<User?> GetUserByIdAsync(int id);
    Task AddUserAsync(User customer);
    Task UpdateUserAsync(User customer);
    Task DeleteUserAsync(int id);
}