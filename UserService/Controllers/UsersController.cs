using Microsoft.AspNetCore.Mvc;
using UserService.Models;
using UserService.Services;

namespace UserService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController(IUsersService usersService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<User>> GetAllUsersAsync()
    {
        var users = await usersService.GetAllUsersAsync();
        return Ok(users);
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetUser(int id)
    {
        var user = await usersService.GetUserByIdAsync(id);
        if (user == null) return NotFound();
        return Ok(user);
    }
    
    [HttpPost]
    public async Task<ActionResult> CreateUser(User user)
    {
        await usersService.AddUserAsync(user);
        return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateUser(int id, User user)
    {
        if (id != user.Id) return BadRequest();
        await usersService.UpdateUserAsync(user);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteUser(int id)
    {
        await usersService.DeleteUserAsync(id);
        return NoContent();
    }
}