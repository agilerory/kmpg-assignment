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
        private decimal? ParseAmount(string value)
        {
            decimal result;
            if (decimal.TryParse(value, out result))
            {
                return result;
            }
            else return null;
        }

        public Model.ParseResult ParseCsvFile(string[] lines)
        {
            var transactions = lines.Skip(1)       // skipping the header line in the csv file, assuming the order is correct
                .Select(line => line
                    .Split(','))
                    //.Select(value => value.Trim())
                .Where(strValues => strValues.Length == 4)
                .Select(strValues => new TransactionParseResult
                    {
                        Account = strValues[0],
                        Description = strValues[1],
                        CurrencyCode = strValues[2],
                        Amount = this.ParseAmount(strValues[3])
                    })
                .Where(t => t.IsValid())
                .Select(t => t.ToTransaction()).ToList();

            return new ParseResult
            {
                IgnoredLinesNumber = lines.Length - 1 - transactions.Count,
                ValidLinesNumber = transactions.Count,
                ValidTransactions = transactions
            };
        }

        private class TransactionParseResult
        {
            public string Account { get; set; }
            public string Description { get; set; }
            public string CurrencyCode { get; set; }
            public decimal? Amount { get; set; }
            public bool IsValid()
            {
                Currency result;
                return Amount != null
                    && Enum.TryParse<Currency>(CurrencyCode, true, out result);
            }

            public Transaction ToTransaction()
            {
                if (!this.IsValid())
                    return null;
                return new Transaction
                {
                    Account = this.Account,
                    Amount = this.Amount.Value,
                    CurrencyCode = this.CurrencyCode,
                    Description = this.Description
                };
            }
        }

        private enum Currency
        {
            USD = 840,
            UAH = 980
            // ...
            // TODO: complete the enum with the whole collection of currencies and their codes
        }
    }
}
