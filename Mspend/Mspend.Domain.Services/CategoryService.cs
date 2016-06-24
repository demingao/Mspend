/* =======================================================================
* create by kikao
* 2016/6/4 11:26:59
* @version 1.0
* =======================================================================*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Mspend.Domain.Entities;
using Mspend.Domain.Interfaces.Services;
using Mspend.Framework.Domain;
using Mspend.Framework.UnitOfWork;

namespace Mspend.Domain.Services
{
    public class CategoryService : ICategoryService
    {
        protected readonly IUnitOfWork UnitOfWork;
        protected readonly IRepository<Category, int> Repository;
        public CategoryService(IUnitOfWork unitOfWork, IRepository<Category, int> repository)
        {
            UnitOfWork = unitOfWork;
            Repository = repository;
        }

        public bool Ctreate(Entities.Category entity)
        {
            UnitOfWork.BeginTransation();
            Repository.Create(entity);
            UnitOfWork.Commit();
            return true;
        }


        public IEnumerable<Category> FindBy(int? userId=null)
        {
            return
                Repository.FindBy(x => (x.Owner == null && userId == null) ||
                    (userId != null && x.Owner.Id == userId)).ToList();
        }


        public Category Get(int id)
        {
            return Repository.Get(id);
        }
        public IEnumerable<Category> Findby(Expression<Func<Category, bool>> exp)
        {
            return Repository.FindBy(exp).ToList();
        }
    }
}
