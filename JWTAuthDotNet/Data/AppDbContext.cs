using Microsoft.EntityFrameworkCore;
using JWTAuthDotNet.Models;

namespace JWTAuthDotNet.Data
{
    public class AppDbContext : DbContext
    {

      public AppDbContext(DbContextOptions options) : base(options){ }  

      public DbSet<User> Users { get; set; }

    }
}
