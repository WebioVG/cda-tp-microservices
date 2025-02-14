using Microsoft.EntityFrameworkCore;
using BookService.Models;

namespace BookService.Data;

public class BookContext(DbContextOptions<BookContext> options) : DbContext(options)
{
    public DbSet<Book> Users { get; set; }
}