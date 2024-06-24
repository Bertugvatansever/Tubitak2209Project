using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gat.Core.Model
{
    public class EtherscanProductGet
    {
        public string productName { get; set; }
        public string productType { get; set; }
        public string productPrice { get; set; }
        public string productAmount { get; set; }
        public string buyerName { get; set; }
        public string buyersurName { get; set; }
        public string sellerName { get; set; }
        public string sellerSurname { get; set; }
        public string startTime { get; set; }
        public string endTime { get; set; }
    }
}
