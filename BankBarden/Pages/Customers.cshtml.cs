using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BankBarden.ViewModels;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Service.CustomerService;
using DataAccessLayer.Models.ENUM;
using Service.AccountService;

namespace BankBarden.Pages
{
    [Authorize(Roles = "Cashier")]
    public class CustomersModel : PageModel
    {
        private readonly IAllCustomerS _allCustS;
        private readonly IAccountS _accountS;

        public CustomersModel(IAllCustomerS allCustS, IAccountS accountS)
        {
            _allCustS = allCustS;
            _accountS = accountS;
        }

        public List<AllCustomersViewModel> Customers { get; set; }
        public CountryE Country { get; set; }
        public string Culom { get; set; }
        public string Order { get; set; }
        public int CurrentPage { get; set; }
        public string Quastion { get; set; }
        public int MaxPage { get; set; }
        public void OnGet(CountryE country, string sortColumn, string sortOrder, int pageNumb, string quastion)
        {
            Country = country;
            Quastion = quastion;
            Culom = _allCustS.GetColumOrder(sortColumn);
            Order = _allCustS.GetSortOrder(sortOrder);
            CurrentPage = _allCustS.GetPageNumber(pageNumb);
            MaxPage = _allCustS.GetMaxPage(Country, Quastion);

            Customers = _allCustS
                .GetCustomers(Country, Culom, Order, CurrentPage, Quastion)
                .Select(c => new AllCustomersViewModel
            {
                Id = c.Id,
                Name = c.Name,
                City = c.City,
                Country = c.Country
            }).ToList();
        }

        public IActionResult OnGetFetchValue(int customerId)
        {
            var accounts = _accountS.GetTotalAccounts(customerId);
            return new JsonResult(new {Value = accounts});

        }
    }
}
