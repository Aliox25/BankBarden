using DataAccessLayer.Models;

namespace BankBarden.ViewModels
{
    public class CustomrtInfoViewmodel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Account> Accounts { get; set; }
        public decimal Balance { get; set; }
    }
}
