using System;

namespace Mspend.Api.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime CreateTime { get; set; }

        //public IEnumerable<MspendRecordModel> Records { get; set; }

    }

    public class DateModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}