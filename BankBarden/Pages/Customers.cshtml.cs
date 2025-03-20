using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BankBarden.ViewModels;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Service.CustomerService;

namespace BankBarden.Pages
{
    [Authorize(Roles = "Cashier")]
    public class CustomersModel : PageModel
    {
        private readonly IAllCustomerS _allCustS;


        public CustomersModel(IAllCustomerS allCustS)
        {
            _allCustS = allCustS;
        }

        public List<AllCustomersViewModel> Customers { get; set; }
        public string Country { get; set; }
        public string Culom { get; set; }
        public string Order { get; set; }
        public int CurrentPage { get; set; }
        public string Quastion { get; set; }
        public int MaxPage { get; set; }
        public void OnGet(string country, string sortColumn, string sortOrder, int pageNumb, string quastion)
        {
            Country = country;
            Quastion = quastion;
            Culom = _allCustS.GetColumOrder(sortColumn);
            Order = _allCustS.GetSortOrder(sortOrder);
            CurrentPage = _allCustS.GetPageNumber(pageNumb);
            MaxPage = _allCustS.GetMaxPage(Country, Quastion);

            Customers = _allCustS.GetCustomers(Country, Culom, Order, CurrentPage, Quastion).Select(c => new AllCustomersViewModel
            {
                Id = c.Id,
                Name = c.Name,
                City = c.City,
                Country = c.Country
            }).ToList();
        }
    }
}
