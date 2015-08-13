using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Transaction
    {
        public string Account { get; set; }
        public string Description { get; set; }
        public string CurrencyCode { get; set; }
        public decimal Amount { get; set; }
    }
}
