using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SampleApplication.Domain.Interface
{
    public interface IRepository<T> where T : class
    {
        T GetById(int id, params string[] includes);
        IEnumerable<T> ListAll(params string[] includes);
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);
        T Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        bool DeleteByID(int id);
        bool Any(Expression<Func<T, bool>> criteria);
        void AddRange(IEnumerable<T> entity);
        int CountByCriteria(Expression<Func<T, bool>> criteria);
        void DeleteRange(IEnumerable<T> entities);
        void UpdateRange(IEnumerable<T> entities);
    }
}
