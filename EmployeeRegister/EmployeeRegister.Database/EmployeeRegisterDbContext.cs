using EmployeeRegister.Database.Configuration;
using EmployeeRegister.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeRegister.Database
{
    public class EmployeeRegisterDbContext : DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<UserRole> UserRole { get; set; }

        public EmployeeRegisterDbContext(DbContextOptions<EmployeeRegisterDbContext> dbContextOptions)
            : base(dbContextOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.AddKeys();

            modelBuilder.Entity<UserRole>().HasKey(sc => new { sc.UserId, sc.RoleId });
            modelBuilder.Entity<UserRole>()
                .HasOne(sc => sc.User)
                .WithMany(s => s.UserRoles)
                .HasForeignKey(sc => sc.UserId);
            modelBuilder.Entity<UserRole>()
                .HasOne(sc => sc.Role)
                .WithMany(s => s.UserRoles)
                .HasForeignKey(sc => sc.RoleId);
        }
    }
}
