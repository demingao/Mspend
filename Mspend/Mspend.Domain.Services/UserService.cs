/* =======================================================================
* create by kikao
* 2016/5/25 21:31:55
* @version 1.0
* =======================================================================*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mspend.Domain.Entities;
using Mspend.Domain.Interfaces.Services;
using Mspend.Framework.Domain;
using Mspend.Framework.UnitOfWork;

namespace Mspend.Domain.Services
{
    public class UserService : IUserService
    {
        protected readonly IRepository<User> Repository;
        protected readonly IUnitOfWork UnitOfWork;

        public UserService(IRepository<User> repository, 
            IUnitOfWork unitOfWork)
        {
            Repository = repository;
            UnitOfWork = unitOfWork;
        }

        public bool Register(User user)
        {
            UnitOfWork.BeginTransation();
            Repository.Create(user);
            UnitOfWork.Commit();
            return true;
        }
    }
}
