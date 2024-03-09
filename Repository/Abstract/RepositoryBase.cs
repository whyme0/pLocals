using pLocals.Data;
using System.Linq.Expressions;

namespace pLocals.Repository.Abstract
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected readonly AppDbContext context;
        public RepositoryBase(AppDbContext context)
        {
            this.context = context;
        }
        public void Create(T entity)
        {
            context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            context.Set<T>().Remove(entity);
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> expression)
        {
            return context.Set<T>().Where(expression);
        }

        public void Update(T entity)
        {
            context.Set<T>().Update(entity);
        }
    }
}
