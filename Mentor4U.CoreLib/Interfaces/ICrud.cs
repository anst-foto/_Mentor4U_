using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Mentor4U.CoreLib.Interfaces;

public interface ICrud<T> where T : BaseAccount
{
    public Task<IEnumerable<T>?> GetAllAsync(CancellationToken ct = default);
    public Task<T?> GetByIdAsync(Guid id, CancellationToken ct = default);
    public Task<IEnumerable<T>?> GetByFilterAsync(Predicate<T> filter, CancellationToken ct = default);
    public Task<T> AddAsync(T entity, CancellationToken ct = default);
    public Task<T> UpdateAsync(T entity, CancellationToken ct = default);
    public Task<bool> DeleteAsync(T entity, CancellationToken ct = default);
}