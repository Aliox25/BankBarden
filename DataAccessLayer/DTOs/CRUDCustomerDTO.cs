using DataAccessLayer.Models.ENUM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DTOs
{
    public class CRUDCustomerDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public GenderE Gender { get; set; }
        public string Streetaddress { get; set; }
        public string City { get; set; }
        public string Postcode { get; set; }
        public CountryE Country { get; set; }
    }
}
