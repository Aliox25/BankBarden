using DataAccessLayer.Models.ENUM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DTOs
{
    public class CountryDTO
    {
        public CountryE Country { get; set; }
        public int UserCount { get; set; }
        public decimal CountryTotalMoney { get; set; }
    }
}
