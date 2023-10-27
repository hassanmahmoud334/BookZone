using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookZone.DataAccess.Repository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(Expression<Func<T,bool>> filter);
        Task<T?> GetFirstOrDefaultAsync(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] properties);

		void Add(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);

    }
}
