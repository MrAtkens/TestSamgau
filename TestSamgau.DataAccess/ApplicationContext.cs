using Microsoft.EntityFrameworkCore;
using TestSamgau.Models;

namespace TestSamgau.DataAccess
{
    public sealed class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
            //Database.Migrate();
        }

        #region DbSets
        public DbSet<User> Users { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            var user = new User
            {
                Id = Guid.Parse("25173041-7745-485e-a025-440c53de55f5"),
                Email = "test@mail.ru",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("123456"),
                FirstName = "TestUser",
                LastName = "TestUser",
                Rating = 0,
            };
            modelBuilder.Entity<User>().HasData(user);
        }
    }

}
