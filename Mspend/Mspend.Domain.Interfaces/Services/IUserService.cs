/* =======================================================================
* create by kikao
* 2016/5/25 21:37:37
* @version 1.0
* =======================================================================*/

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Mspend.Domain.Entities;

namespace Mspend.Domain.Interfaces.Services
{
    public interface IUserService
    {
        bool Register(User user);
        User Login(string userName, string password);
        IEnumerable<User> FindBy(Expression<Func<User,bool>> exp);
    }
}
