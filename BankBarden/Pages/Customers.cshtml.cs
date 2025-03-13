using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BankBarden.ViewModels;

namespace BankBarden.Pages
{
    public class CustomersModel : PageModel
    {
        private readonly BankAppDataContext _dbContext;


        public CustomersModel(BankAppDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<AllCustomersViewModel> Customers { get; set; }

        public void OnGet(string coun)
        {
            Customers = _dbContext.Customers
                .Where(c => c.Country == coun)
                .Select(c => new AllCustomersViewModel
                {
                    Id = c.CustomerId,
                    Namn = c.Givenname,
                    City = c.City
                })
                .ToList();
        }
    }
}
