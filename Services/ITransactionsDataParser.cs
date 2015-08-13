using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    interface ITransactionsDataParser
    {
        ParseResult ParseCsvFile(string[] lines);
    }
}
