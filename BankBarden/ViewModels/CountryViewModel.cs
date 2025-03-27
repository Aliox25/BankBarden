using DataAccessLayer.DTOs;

namespace BankBarden.ViewModels
{
    public class CountryViewModel
    {
        public string Country { get; set; }
        public int UserCount { get; set; }
        public decimal CountryTotalMoney { get; set; }
    }
}
