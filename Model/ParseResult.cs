using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class ParseResult
    {
        public IEnumerable<Transaction> ValidTransactions { get; set; }
        public int ValidLinesNumber { get; set; }
        public int IgnoredLinesNumber { get; set; }
    }
}
