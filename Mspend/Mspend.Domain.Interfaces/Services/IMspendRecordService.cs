/* =======================================================================
* create by kikao
* 2016/6/4 11:29:36
* @version 1.0
* =======================================================================*/

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Mspend.Domain.Entities;

namespace Mspend.Domain.Interfaces.Services
{
    public interface IMspendRecordService
    {
        MspendRecord Create(MspendRecord entity);
        bool MakeDelete(MspendRecord entity);
        IEnumerable<MspendRecord> Findby(Expression<Func<MspendRecord, bool>> exp);
    }
}
