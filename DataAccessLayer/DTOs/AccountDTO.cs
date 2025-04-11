using DataAccessLayer.Models.ENUM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DTOs
{
    public class AccountDTO
    {
        public int Id { get; set; }
        public decimal Balance { get; set; }
        public AccFrequencyE Frequency { get; set; }
    }
}
