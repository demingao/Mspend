/* =======================================================================
* create by kikao
* 2016/5/25 23:12:19
* @version 1.0
* =======================================================================*/
using FluentNHibernate.Mapping;

namespace Mspend.Domain.Entities.Mapper
{
   public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Id(x => x.Id);
            Map(x => x.LoginName).Unique();
            Map(x => x.Password).Not.Nullable();
            Map(x => x.ProfilePicture);
            Map(x => x.NickName);
            Map(x => x.CreateTime).Not.Nullable();
        }
    }
}
