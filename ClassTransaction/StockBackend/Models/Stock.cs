using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace StockBackend
{
    public class Stock
    {
        [Key]
        public int StockId { get; set; }
        [Required]
        [MaxLength(10)]
        public string CodeNum { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public string? Description { get; set; }

        public List<TransactionRecord>? TransactionRecords { get; set; }

    }
}
