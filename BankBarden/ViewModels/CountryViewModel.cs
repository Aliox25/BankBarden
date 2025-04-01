using DataAccessLayer.Models.ENUM;

namespace BankBarden.ViewModels
{
    public class CountryViewModel
    {
        public CountryE Country { get; set; }
        public int UserCount { get; set; }
        public decimal CountryTotalMoney { get; set; }
    }
}
