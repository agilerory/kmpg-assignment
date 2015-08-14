using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class TransactionsService
    {
        public void AddRange(IEnumerable<Transaction> transactions)
        {
            using (TransactionsDBContext context = new TransactionsDBContext())
            {
                context.Transactions.AddRange(transactions);
                context.SaveChanges();
            }
        }
    }
}
