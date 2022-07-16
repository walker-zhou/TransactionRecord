using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace StockBackend
{
    public class TransactionRecord
    {
        [Key]
        public int TransactionId { get; set; }
        public bool TradeType { get; set; }
        public decimal TreeDayMax { get; set; }
        public decimal DealPrice { get; set; }

        public DateTime DealTime { get; set; }
        public string? Description { get; set; }
        public int StockID { get; set; }
        public Stock Stock { get; set; }
    }
}
