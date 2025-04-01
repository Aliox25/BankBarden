using DataAccessLayer.Models.ENUM;

namespace BankBarden.ViewModels
{
    public class AllCustomersViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public CountryE Country { get; set; }
    }
}
