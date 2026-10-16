using System.Threading.Tasks;

namespace Mentor4U.CoreLib.Interfaces;

public interface ICud<T>
{
    public Task<T> Create(T entity);
    public Task<T> Update(T entity);
    public Task<T> Delete(T entity);
}