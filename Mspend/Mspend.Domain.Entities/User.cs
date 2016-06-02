/* =======================================================================
* create by kikao
* 2016/5/25 20:32:51
* @version 1.0
* =======================================================================*/

using System;
using Mspend.Framework.Domain;

namespace Mspend.Domain.Entities
{
    public class User : IEntity
    {
        public virtual int Id { get; set; }
        public virtual string LoginName { get; set; }
        public virtual string Password { get; set; }
        public virtual string ProfilePicture { get; set; }
        public virtual string NickName { get; set; }
        public virtual DateTime CreateTime { get; set; }
    }
}
