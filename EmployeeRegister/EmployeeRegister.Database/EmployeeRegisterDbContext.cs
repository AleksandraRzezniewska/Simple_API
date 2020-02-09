using EmployeeRegister.Database.Configuration;
using EmployeeRegister.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeRegister.Database
{
    public class EmployeeRegisterDbContext : DbContext
    {
        public DbSet<User> User { get; set; }

        public EmployeeRegisterDbContext(DbContextOptions<EmployeeRegisterDbContext> dbContextOptions)
            : base(dbContextOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.AddKeys();
        }
    }
}
