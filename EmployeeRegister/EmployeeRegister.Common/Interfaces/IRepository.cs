using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeRegister.Common.Interfaces
{
    public interface IRepository
    {
        Task<IEnumerable<T>> GetAll<T>()
            where T : class, IEntity;

        Task<T> GetById<T>(Guid id)
            where T : class, IEntity;

        Task Add<T>(T entity)
            where T : class, IEntity;

        Task Save();
    }
}
