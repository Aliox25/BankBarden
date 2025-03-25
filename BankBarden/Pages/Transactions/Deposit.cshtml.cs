using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.AccountService;
using Service.TransactionsService;
using System.ComponentModel.DataAnnotations;

namespace BankBarden.Pages.Transactions
{
    [BindProperties]
    public class DepositModel : PageModel
    {
        private readonly IAccountS _accountS;
        private readonly IDepositS _depositS;

        public DepositModel(IAccountS accountS, IDepositS depositS)
        {
            _accountS = accountS;
            _depositS = depositS;
        }




        public int AccountId { get; set; }
        public int CustomerId { get; set; }
        public decimal Balance { get; set; }


        [Range(1, 5000, ErrorMessage = "Amount can only be between 1 and 5000!")]
        public decimal Amount { get; set; }
        public DateTime DepositDate { get; set; }

        [MaxLength(100, ErrorMessage ="Comment is to long!")]
        public string? Comment { get; set; }

        public void OnGet(int accountId, int customerId)
        {
            DepositDate = DateTime.Now.AddHours(1);
            AccountId = accountId;
            CustomerId = customerId;
            Balance = _accountS.GetSingelAccount(accountId).Balance;

        }

        public IActionResult OnPost(int accountId, int customerId)
        { 

            if (ModelState.IsValid)
            {
                _depositS.MakeADeposit(accountId, Amount, Comment);
                _accountS.Update();
                return RedirectToPage("/CustomerInfo", new { custId = customerId });
            }
            Balance = _accountS.GetSingelAccount(accountId).Balance;
            return Page();


        }


    }

}
