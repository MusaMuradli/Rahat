using Microsoft.EntityFrameworkCore;

namespace Rahat.Persistence.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }
}