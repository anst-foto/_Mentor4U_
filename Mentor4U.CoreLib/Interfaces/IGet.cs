using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mentor4U.CoreLib.Interfaces;

public interface IGet<T>
{
    public Task<IEnumerable<T>> GetAll();
    public Task<T> GetById(Guid id);
    public Task<IEnumerable<T>> GetByFilter(Predicate<T> filter);
}