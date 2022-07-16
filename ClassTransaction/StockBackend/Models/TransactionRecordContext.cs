using Microsoft.EntityFrameworkCore;

namespace StockBackend.Models
{
    public class TransactionRecordContext:DbContext
    {
        public TransactionRecordContext(DbContextOptions<TransactionRecordContext> options)
           : base(options)
        {
        }

        public DbSet<Stock> Stocks { get; set; }
        public DbSet<TransactionRecord> TransactionRecords { get; set; }

    }
}
