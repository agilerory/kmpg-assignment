using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class TransactionsDataParser : ITransactionsDataParser
    {
        public Model.ParseResult ParseCsvFile(string[] lines)
        {
            return new ParseResult
            {
                IgnoredLinesNumber = 0,
                ValidLinesNumber = 0,
                ValidTransactions = Enumerable.Empty<Transaction>()
            };
        }
    }
}
