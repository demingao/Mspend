using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api.Models
{
    public class RecentModel
    {
        public string CategoryName { get; set; }
        public IEnumerable<MspendRecordModel> MspendRecords { get; set; }
    }
}