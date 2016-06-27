/* =======================================================================
* create by kikao
* 2016/6/3 21:31:20
* @version 1.0
* =======================================================================*/
using FluentNHibernate.Mapping;

namespace Mspend.Domain.Entities.Mapper
{
    public class CategoryMap : ClassMap<Category>
    {
        public CategoryMap()
        {
            Id(x => x.Id);
            Map(x => x.Name).Not.Nullable();
            Map(x => x.Description);
            Map(x => x.Sort).Nullable();
            Map(x => x.CreateTime).Not.Nullable();
            References(x => x.Parent, "ParentId").Nullable();
            References(x => x.Owner, "OwnerId").Nullable();
        }
    }
}
