/* =======================================================================
* create by kikao
* 2016/6/3 21:52:02
* @version 1.0
* =======================================================================*/
using FluentNHibernate.Mapping;

namespace Mspend.Domain.Entities.Mapper
{
    public class MspendRecordMap:ClassMap<MspendRecord>
    {
        public MspendRecordMap()
        {
            Id(x => x.Id);
            Map(x => x.Money).Not.Nullable();
            Map(x => x.Name).Not.Nullable();
            Map(x => x.Description);
            Map(x => x.CreateTime).Not.Nullable();
            Map(x => x.RecordTime).Not.Nullable();
            References(x => x.Owner, "OwnerId").Not.Nullable();
            References(x => x.Category, "CategoryId").Not.Nullable();
        }
    }
}
