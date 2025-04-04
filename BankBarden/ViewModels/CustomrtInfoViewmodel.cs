using DataAccessLayer.Models;
using DataAccessLayer.Models.ENUM;

namespace BankBarden.ViewModels
{
    public class CustomrtInfoViewmodel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public GenderE Gender { get; set; }
        public string Streetaddress { get; set; }
        public string City { get; set; }
        public string Zipcode { get; set; }
        public CountryE Country { get; set; }
        public decimal Balance { get; set; }
    }
}
