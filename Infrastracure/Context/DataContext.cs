

using Infrastracture.Entities;
using Infrastracure.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastracture.Context;

public class DataContext(DbContextOptions<DataContext> options) : IdentityDbContext<UserEntity>(options)
{

    public DbSet<CategoryEnitity> Categories { get; set; }
    public DbSet<CourseEntity> Courses { get; set; }

    public DbSet<AddressEntity> Addresses { get; set; }

}

