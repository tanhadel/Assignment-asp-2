using Microsoft.EntityFrameworkCore;
using SubApi_1.Entities;

namespace SubApi_1.Contexts;

public class ApiSubContext(DbContextOptions<ApiSubContext> options) : DbContext(options)
{
    public DbSet<SubEntity> Subscribers { get; set; }
}
