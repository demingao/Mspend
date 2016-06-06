/* =======================================================================
* create by kikao
* 2016/5/24 23:32:03
* @version 1.0
* =======================================================================*/
using System;
using System.Linq;
using Mspend.Framework.Domain;
using Mspend.Framework.UnitOfWork;
using NHibernate;
using NHibernate.Linq;

namespace Mspend.Data
{
    public class Repository<T, TKey> : IRepository<T, TKey> where T : IEntity
    {
        private readonly UnitOfWork _unitOfWork;

        protected ISession Session
        {
            get { return _unitOfWork.Session; }
        }

        public Repository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = (UnitOfWork)unitOfWork;
        }

        public IQueryable<T> All()
        {
            return Session.Query<T>();
        }

        public IQueryable<T> FindBy(System.Linq.Expressions.Expression<Func<T, bool>> func)
        {
            return Session.Query<T>().Where(func).AsQueryable();
        }

        public T Get(TKey id)
        {
            return Session.Get<T>(id);
        }

        public TKey Create(T entity)
        {
            return (TKey)Session.Save(entity);
        }

        public void Update(T entity)
        {
            Session.Update(entity);
        }

        public void Delete(T entity)
        {
            Session.Delete(entity);
        }
    }
}
