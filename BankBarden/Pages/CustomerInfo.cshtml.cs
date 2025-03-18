using BankBarden.ViewModels;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BankBarden.Pages
{
    [Authorize(Roles = "Cashier")]
    public class CustomerInfoModel : PageModel
    {
        private readonly BankAppDataContext _dbContext;

        public CustomerInfoModel(BankAppDataContext dbContext)
        {
            _dbContext = dbContext;
        }
        public CustomrtInfoViewmodel Customer {  get; set; }
        public void OnGet(int custId)
        {
            var quary = _dbContext.Customers
                .Include(c => c.Dispositions)
                .ThenInclude(c => c.Account)
                .ThenInclude(c => c.Transactions)
                .Where(c => c.CustomerId == custId)
                .Select(c => new CustomrtInfoViewmodel
                {
                    Id = c.CustomerId,
                    FirstName = c.Givenname,
                    LastName = c.Surname,
                    Accounts = c.Dispositions.Select(d => d.Account).ToList(),
                    Balance = c.Dispositions.Select(d => d.Account.Transactions.Sum(t => t.Amount)).Sum()
                });

            Customer = quary.First();
        }
    }
}
