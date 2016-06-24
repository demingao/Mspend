/* =======================================================================
* create by kikao
* 2016/6/4 11:25:13
* @version 1.0
* =======================================================================*/

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Mspend.Domain.Entities;

namespace Mspend.Domain.Interfaces.Services
{
    public interface ICategoryService
    {
        bool Ctreate(Category entity);
        IEnumerable<Category> FindBy(int? userId=null);
        IEnumerable<Category> Findby(Expression<Func<Category, bool>> exp);
        Category Get(int id);
      
    }
}
