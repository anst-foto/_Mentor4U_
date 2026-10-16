using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Mentor4U.CoreLib.Models;

namespace Mentor4U.CoreLib.Interfaces;

public interface ICrud<T> where T : BaseAccount
{
    public Task<Result<IEnumerable<T>>> GetAllAsync(CancellationToken ct = default);
    public Task<Result<T>> GetByIdAsync(Guid id, CancellationToken ct = default);
    public Task<Result<IEnumerable<T>>> GetByFilterAsync(Predicate<T> filter, CancellationToken ct = default);
    public Task<Result<T>> AddAsync(T entity, CancellationToken ct = default);
    public Task<Result<T>> UpdateAsync(T entity, CancellationToken ct = default);
    public Task<Result<T>> DeleteAsync(T entity, CancellationToken ct = default);
}