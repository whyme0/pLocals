using System.Linq.Expressions;

namespace pLocals.Repository.Abstract
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> Find(Expression<Func<T, T>> expression);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
