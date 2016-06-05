/* =======================================================================
* create by kikao
* 2016/5/25 21:31:55
* @version 1.0
* =======================================================================*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using Mspend.Domain.Entities;
using Mspend.Domain.Interfaces.Services;
using Mspend.Framework.Domain;
using Mspend.Framework.Helper;
using Mspend.Framework.UnitOfWork;

namespace Mspend.Domain.Services
{
    public class UserService : IUserService
    {
        protected readonly IRepository<User,int> Repository;
        protected readonly IUnitOfWork UnitOfWork;

        public UserService(IRepository<User, int> repository,
            IUnitOfWork unitOfWork)
        {
            Repository = repository;
            UnitOfWork = unitOfWork;
        }

        public bool Register(User user)
        {
            user.Password = Md5.Encrypt16(user.Password);
            UnitOfWork.BeginTransation();
            Repository.Create(user);
            UnitOfWork.Commit();
            return true;
        }

        public User Login(string userName, string password)
        {
            if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(password)) return null;
            var user = Repository.FindBy(x => x.LoginName == userName).FirstOrDefault();
            if (user == null || user.Password != Md5.Encrypt16(password)) return null;
            user.Password = null;
            return user;
        }
    }
}
