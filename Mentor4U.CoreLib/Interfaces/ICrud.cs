using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mentor4U.CoreLib.Interfaces;

public interface ICrud<T>
{
    public Task<IEnumerable<T>> GetAllAsync();
    public Task<T> GetByIdAsync(Guid id);
    public Task<IEnumerable<T>> GetByFilterAsync(Predicate<T> filter);
    public Task<T> AddAsync(T entity);
    public Task<T> UpdateAsync(T entity);
    public Task<bool> DeleteAsync(T entity);
}