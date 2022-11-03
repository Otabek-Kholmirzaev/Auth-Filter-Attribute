using Auth.Api.Entities;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace Auth.Api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<UserEntity> Users { get; set; }
    public DbSet<ProblemEntity> Problems { get; set; }
}
