using BankBarden.ViewModels;
using DataAccessLayer.Models.ENUM;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.AccountService;
using Service.CustomerService;

namespace BankBarden.Pages
{
    [ResponseCache(Duration = 30, VaryByQueryKeys = new[]{ "country" })]
    public class Top10CustomersModel : PageModel
    {
        private readonly IAllCustomerS _allCustS;

        public Top10CustomersModel(IAllCustomerS allCustS)
        {
            _allCustS = allCustS;
        }

        public List<AllCustomersViewModel> Customers { get; set; }
        public CountryE Country { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public void OnGet(CountryE country)
        {
            Country = country;
            Customers = _allCustS.Get10Customer(Country)
                .Select(c => new AllCustomersViewModel
            {
                Id = c.Id,
                Name = c.Name,
                City = c.City,
                Country = c.Country
            }).ToList();
        }
    }
}
