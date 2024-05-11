using Microsoft.EntityFrameworkCore;
using System.Reflection;
using UnitOfWork.Entities;

namespace UnitOfWork.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options) => Database.EnsureCreated();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
