/* =======================================================================
* create by kikao
* 2016/5/25 20:39:01
* @version 1.0
* =======================================================================*/

using System;
using System.Collections.Generic;
using Mspend.Framework.Domain;

namespace Mspend.Domain.Entities
{
    public class Category : IEntity
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual int Sort { get; set; }
        public virtual  Category Parent { get; set; }
       // public virtual  IEnumerable<Category> Children { get; set; }
        public virtual User Owner { get; set; }
        public virtual DateTime CreateTime { get; set; }
    }
}
