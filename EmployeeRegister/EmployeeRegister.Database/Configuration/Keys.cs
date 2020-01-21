using EmployeeRegister.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EmployeeRegister.Database.Configuration
{
    public static class Keys
    {
        public static ModelBuilder AddKeys(this ModelBuilder modelBuilder)
        {
            var baseType = typeof(EntityBase);
            var types = modelBuilder.Model.GetEntityTypes()
                .Where(t => t.ClrType.IsSubclassOf(baseType));

            foreach (var type in types)
            {
                modelBuilder.Entity(type.Name).HasKey(new string[] { nameof(EntityBase.Id) });
            }

            return modelBuilder;
        }
    }
}
