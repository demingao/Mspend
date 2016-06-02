/* =======================================================================
* create by kikao
* 2016/5/25 20:39:01
* @version 1.0
* =======================================================================*/

using System.Collections.Generic;
using Mspend.Framework.Domain;

namespace Mspend.Domain.Entities
{
    public class Category : IEntity
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public  Category Parent { get; set; }
        public  IEnumerable<Category> Children { get; set; }
        public User Owner { get; set; }
    }
}
