/* =======================================================================
* create by kikao
* 2016/5/25 20:37:46
* @version 1.0
* =======================================================================*/

using System;
using Mspend.Framework.Domain;

namespace Mspend.Domain.Entities
{
    public class MspendRecord : IEntity
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual decimal Money { get; set; }
        public virtual string Description { get; set; }
        public virtual DateTime RecordTime { get; set; }
        public virtual DateTime CreateTime { get; set; }
        public virtual User Owner { get; set; }
        public virtual Category Category { get; set; }
    }
}
