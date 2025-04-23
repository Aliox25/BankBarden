using DataAccessLayer.Models.ENUM;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Service.AccountService;
using System.ComponentModel.DataAnnotations;

namespace BankBarden.Pages.AccountCRUD
{
    [BindProperties]
    public class DeletAccountModel : PageModel
    {
        private readonly IAccountS _accountS;

        public DeletAccountModel(IAccountS accountS)
        {
            _accountS = accountS;
        }

        public int CustomerId { get; set; }
        public int AccountId { get; set; }

        public decimal Balance { get; set; }

        public AccFrequencyE Frequency { get; set; }

        public string AccountType { get; set; }
        public void OnGet(int accountId, int customerId)
        {
            CustomerId = customerId;
            AccountId = accountId;
            var account = _accountS.GetSingelAccount(accountId);
            Balance = account.Balance;
            Frequency = account.Frequency;
            AccountType = account.AccountType;
        }

        public IActionResult OnPost()
        {
            if (Balance > 0)
            {
                ModelState.AddModelError("Balance", "You have money on this account. Transfer your money to a difrent account!");
            }
            if(ModelState.IsValid)
            {
                _accountS.DeleteAccount(AccountId);
                return RedirectToPage("/CustomerInfo", new { custId = CustomerId });
            }
            return Page();
        }

    }
}
