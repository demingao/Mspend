using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api.Models
{
    public class MspendRecordModel
    {
        public int Id { get; set; }
        public  string Name { get; set; }
        public  decimal Money { get; set; }
        public  string Description { get; set; }
        public  string RecordTime { get; set; }
        public  DateTime CreateTime { get; set; }
        public int CatId { get; set; }
        public CategoryModel Category { get; set; }
    }
}