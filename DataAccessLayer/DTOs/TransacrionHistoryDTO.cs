using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DTOs
{
    public class TransacrionHistoryDTO
    {
        public int Id { get; set; }
        public DateOnly Date { get; set; }
        public decimal Amount { get; set; }
        public decimal Balance { get; set; }
        public string? Symbol { get; set; }
    }
}
