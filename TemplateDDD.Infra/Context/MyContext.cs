using TemplateDDD.Domain.Entities;
using TemplateDDD.Infra.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace TemplateDDD.Infra.Context
{
    public class MyContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }
        public IConfiguration _configuration { get; }

        public MyContext(DbContextOptions<MyContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string? connectionString = _configuration.GetConnectionString("Default");
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserEntity>(new UserMap().Configure);
        }

    }
}
