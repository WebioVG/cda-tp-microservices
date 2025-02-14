using UserService.Models;
using UserService.Repositories;

namespace UserService.Services;

public class UsersService() : IUsersService
{
    private readonly IUserRepository _userRepository;
    
    public UsersService(IUserRepository userRepository) : this()
    {
        _userRepository = userRepository;
    }
    
    public async Task<IEnumerable<User>> GetAllUsersAsync()
    {
        return await _userRepository.GetAllAsync();
    }

    public async Task<User?> GetUserByIdAsync(int id)
    {
        return await _userRepository.GetByIdAsync(id);
    }

    public async Task AddUserAsync(User customer)
    {
        await _userRepository.AddAsync(customer);
    }

    public async Task UpdateUserAsync(User customer)
    {
        await _userRepository.UpdateAsync(customer);
    }

    public async Task DeleteUserAsync(int id)
    {
        var user = await _userRepository.GetByIdAsync(id);
        if (user == null)
        {
            throw new Exception($"User with ID {id} does not exist.");
        }

        await _userRepository.DeleteAsync(id);
    }
}