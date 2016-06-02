/* =======================================================================
* create by kikao
* 2016/5/24 22:16:26
* @version 1.0
* =======================================================================*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mspend.Framework.UnitOfWork
{
    public interface IUnitOfWork
    {
        void BeginTransation();
        void Commit();
        void Rollback();        
    }
}
