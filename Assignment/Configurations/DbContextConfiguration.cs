using Infrastracture.Context;
using Microsoft.EntityFrameworkCore;

using SubApi_1.Contexts;
using System.Runtime.CompilerServices;


namespace Assignment.Configurations;

public static class DbContextonfiguration
{
    public static void RegisterDbContexts(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApiSubContext>(x => x.UseSqlServer(configuration.GetConnectionString("SqlServer2")));
    }



}
