using UserService.Data;
using UserService.Repositories;
using UserService.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<UserContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))));

// Injection des d�pendances
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUsersService, UsersService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseAuthorization();
app.MapControllers();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();