using Microsoft.EntityFrameworkCore;
using BorrowingService.Models;

namespace BorrowingService.Data;

public class BorrowingContext(DbContextOptions<BorrowingContext> options) : DbContext(options)
{
    public DbSet<Borrowing> Borrowings { get; set; }
}