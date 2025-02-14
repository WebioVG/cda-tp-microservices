using Microsoft.EntityFrameworkCore;
using UserService.Data;
using UserService.Models;

namespace UserService.Repositories;

public class UserRepository(UserContext context) : IUserRepository
{
    public async Task<IEnumerable<User>> GetAllAsync() =>
        await context.Users.ToListAsync();

    public async Task<User?> GetByIdAsync(int id) =>
        await context.Users.FindAsync(id);

    public async Task AddAsync(User customer)
    {
        await context.Users.AddAsync(customer);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(User customer)
    {
        context.Users.Update(customer);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var user = await context.Users.FindAsync(id);
        if (user != null)
        {
            context.Users.Remove(user);
            await context.SaveChangesAsync();
        }
    }
}