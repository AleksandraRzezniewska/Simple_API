using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EmployeeRegister.Database
{
    public class DesignTimeEmployeeRegisterDbContextFactory : IDesignTimeDbContextFactory<EmployeeRegisterDbContext>
    {
        public EmployeeRegisterDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<EmployeeRegisterDbContext>();

            optionsBuilder.UseSqlServer("Server=(LocalDb)\\localDB; Database=Test;");

            return new EmployeeRegisterDbContext(optionsBuilder.Options);
        }
    }
}
