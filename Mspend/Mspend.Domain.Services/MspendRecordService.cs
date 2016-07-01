/* =======================================================================
* create by kikao
* 2016/6/4 11:31:37
* @version 1.0
* =======================================================================*/
using System;
using System.Collections.Generic;
using System.Linq;
using Mspend.Domain.Entities;
using Mspend.Domain.Interfaces.Services;
using Mspend.Framework.Domain;
using Mspend.Framework.UnitOfWork;

namespace Mspend.Domain.Services
{
    public class MspendRecordService : IMspendRecordService
    {
        protected readonly IUnitOfWork UnitOfWork;
        protected readonly IRepository<MspendRecord, int> Repository;
        public MspendRecordService(IUnitOfWork unitOfWork, IRepository<MspendRecord, int> repository)
        {
            UnitOfWork = unitOfWork;
            Repository = repository;
        }

        public MspendRecord Create(MspendRecord entity)
        {
            UnitOfWork.BeginTransation();
            var id = Repository.Create(entity);
            var res = Repository.Get(id);
            UnitOfWork.Commit();
            return res;
        }

        public bool MakeDelete(MspendRecord entity)
        {
            throw new NotImplementedException();
        }


        public IEnumerable<MspendRecord> Findby(System.Linq.Expressions.Expression<Func<MspendRecord, bool>> exp)
        {
            return Repository.FindBy(exp).ToList();
        }
    }
}
