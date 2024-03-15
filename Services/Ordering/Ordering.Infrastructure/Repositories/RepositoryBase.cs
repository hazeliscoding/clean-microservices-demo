using System.Linq.Expressions;
using Ordering.Core.Common;
using Ordering.Core.Repositories;

namespace Ordering.Infrastructure.Repositories;

public class RepositoryBase<T> : IAsyncRepository<T> where T : EntityBase
{
    public Task<IReadOnlyList<T>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public Task<T> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<T> AddAsync(T entity)
    {
        throw new NotImplementedException();
    }

    public Task<T> UpdateAsync(T entity)
    {
        throw new NotImplementedException();
    }

    public Task<T> DeleteAsync(T entity)
    {
        throw new NotImplementedException();
    }
}