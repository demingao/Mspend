using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime CreateTime { get; set; }
<<<<<<< HEAD
        //public IEnumerable<MspendRecordModel> Records { get; set; }
=======
       // public IEnumerable<MspendRecordModel> Records { get; set; }
>>>>>>> 662133fc942e02e808162917c4d72e5b412a0ae3
    }
}