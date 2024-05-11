using Microsoft.EntityFrameworkCore;
using UnitOfWork.Abstractions;
using UnitOfWork.Context;

namespace UnitOfWork.Extensions;

public static class ServiceExtension
{
    public static void AddDbContext(this IServiceCollection services, ConfigurationManager configurationManager) =>
        services.AddDbContext<AppDbContext>(option => option
            .UseSqlServer(configurationManager.GetConnectionString("DefaultConnection")));

    public static void AddServices(this IServiceCollection services) =>
        services.AddScoped<IUnitOfWork, Repositories.UnitOfWork>();
}
