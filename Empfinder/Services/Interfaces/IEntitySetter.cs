using System;
using System.Linq.Expressions;

namespace Empfinder.Services;

public interface IEntitySetter<T> : IService
{
    Task RemoveAsync(Expression<Func<T, bool>> predicate);
    Task RemoveRangeAsync(Expression<Func<T, bool>> predicate);
    Task AddAsync(T newEntity);
    Task UpdateAsync(Expression<Func<T, bool>> predicate, T newEntity);
    Task UpdateOrAddAsync(Expression<Func<T, bool>> predicate, T newEntity);
}