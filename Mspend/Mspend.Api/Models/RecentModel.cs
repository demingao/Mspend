using System.Collections.Generic;

namespace Mspend.Api.Models
{
    public class RecentModel
    {
        public string CategoryName { get; set; }
        public IEnumerable<MspendRecordModel> MspendRecords { get; set; }
        public decimal TotalMoney { get; set; }
    }
}