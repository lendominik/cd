using Microsoft.EntityFrameworkCore;
using UserManager.API.Entities;

namespace UserManager.API.Persistence;

public class UserManagerDbContext(DbContextOptions<UserManagerDbContext> dbContextOptions) : DbContext(dbContextOptions)
{
    public DbSet<User> Users { get; set; }
}