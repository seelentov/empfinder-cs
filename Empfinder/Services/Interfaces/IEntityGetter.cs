using System.Linq.Expressions;

namespace Empfinder.Services;

public interface IEntityGetter<T> : IService
{
    Task<T?> GetAsync(Expression<Func<T, bool>> predicate);
    Task<T?> GetByIdAsync(int Id);
    Task<IEnumerable<T>> GetRangeAsync(Expression<Func<T, bool>> predicate);
    Task<IEnumerable<T>> GetAllAsync();
}