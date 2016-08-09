using System.Collections.Generic;

namespace Mspend.Api.Models
{
    public class RecordSearchModel
    {
        public RecordSearchModel()
        {
            PageIndex = 1;
            PageSize = 10;
            OrderType = 1;
        }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int DateType { get; set; }
        public List<int> CategoryTypes { get; set; }
        public int OrderType { get; set; }
    }
}