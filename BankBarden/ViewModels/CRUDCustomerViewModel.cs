using DataAccessLayer.Models.ENUM;

namespace BankBarden.ViewModels
{
    public class CRUDCustomerViewModel
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
