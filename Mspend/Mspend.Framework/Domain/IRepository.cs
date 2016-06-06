/* =======================================================================
* create by kikao
* 2016/5/24 22:18:03
* @version 1.0
* =======================================================================*/
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Mspend.Framework.Domain
{
    public interface IRepository<T, TKey> where T : IEntity
    {
        IQueryable<T> All();
        IQueryable<T> FindBy(Expression<Func<T,bool>> func);
        T Get(TKey id);
        TKey Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
