using DataAccessLayer.Models.ENUM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DTOs
{
    public class AllCustomerDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public CountryE Country { get; set; }
    }
}
