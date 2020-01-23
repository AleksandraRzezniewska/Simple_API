using EmployeeRegister.Common.Configuration;
using EmployeeRegister.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace EmployeeRegister.Database
{
    public class EmployeeRegisterDbContextFactory : IDbContextFactory<EmployeeRegisterDbContext>
    {
        private readonly ApplicationConfiguration _applicationConfiguration;

        public EmployeeRegisterDbContextFactory(IOptions<ApplicationConfiguration> options)
        {
            _applicationConfiguration = options.Value;
        }

        public EmployeeRegisterDbContext Create()
        {
            var optionsBuilder = new DbContextOptionsBuilder<EmployeeRegisterDbContext>();

            optionsBuilder.UseSqlServer(_applicationConfiguration.ConnectionStrings); ;

            return new EmployeeRegisterDbContext(optionsBuilder.Options);
        }
    }
}
