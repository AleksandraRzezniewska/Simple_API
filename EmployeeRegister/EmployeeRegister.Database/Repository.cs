using EmployeeRegister.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeRegister.Database
{
    public class Repository : IRepository
    {
        private readonly IDbContextFactory<EmployeeRegisterDbContext> _factory;
        private EmployeeRegisterDbContext _context;

        public EmployeeRegisterDbContext Context
        {
            get
            {
                if (_context == null)
                {
                    _context = _factory.Create();
                }

                return _context;
            }
        }

        public Repository(IDbContextFactory<EmployeeRegisterDbContext> factory)
        {
            _factory = factory;
        }

        public async Task Save()
        {
            await Context.SaveChangesAsync();
        }

        public async Task Add<T>(T entity)
            where T : class, IEntity
        {
            await Context.Set<T>().AddAsync(entity);
        }

        public async Task<IEnumerable<T>> GetAll<T>()
            where T : class, IEntity
        {
            return await Context.Set<T>().ToListAsync();
        }

        public async Task<T> GetById<T>(Guid id)
            where T : class, IEntity
        {
            return await Context.Set<T>().FindAsync(id);
        }
    }
}
