using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using ParserTestMakaev.BL;
using System;


namespace ParserTestMakaev.DAL
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Task> Tasks { get; set; }
        public virtual DbSet<Product> Products { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
    }
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
           // IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile(@Directory.GetCurrentDirectory() + "/../ParserTestMakaev.API/appsettings.json").Build();
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
           // var connectionString = configuration.GetConnectionString("DatabaseConnection");
            builder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ParserTestMakaevDb;Trusted_Connection=True");
            return new ApplicationDbContext(builder.Options);
        }
    }
}
