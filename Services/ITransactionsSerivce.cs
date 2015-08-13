using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    interface ITransactionsSerivce
    {
        IEnumerable<Transaction> GetTransactions(int take = 100, int skip = 0);
        void AddTransactionsRange(IEnumerable<Transaction> transactions);
    }
}
