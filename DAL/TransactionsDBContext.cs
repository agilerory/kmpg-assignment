using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DAL
{
    public class TransactionsDBContext : DbContext
    {
        public DbSet<Model.Transaction> Transactions { get; set; }
    }
}
