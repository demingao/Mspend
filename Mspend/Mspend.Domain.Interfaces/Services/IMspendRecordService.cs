/* =======================================================================
* create by kikao
* 2016/6/4 11:29:36
* @version 1.0
* =======================================================================*/

using Mspend.Domain.Entities;

namespace Mspend.Domain.Interfaces.Services
{
    public interface IMspendRecordService
    {
        MspendRecord Create(MspendRecord entity);
        bool MakeDelete(MspendRecord entity);
    }
}
