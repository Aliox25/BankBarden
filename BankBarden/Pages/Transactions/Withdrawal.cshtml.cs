using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.AccountService;
using Service.TransactionsService;
using System.ComponentModel.DataAnnotations;

namespace BankBarden.Pages.Transactions
{
    [BindProperties]
    public class WithdrawalModel : PageModel
    {
        private readonly IAccountS _accountS;
        private readonly IWithdrawalS _withdrS;

        public WithdrawalModel(IAccountS accountS, IWithdrawalS withdrS)
        {
            _accountS = accountS;
            _withdrS = withdrS;
        }

        public int AccountId { get; set; }
        public int CustomerId { get; set; }
        public decimal Balance { get; set; }


        [Range(1, 5000, ErrorMessage = "Amount can only be between 1 and 5000!")]
        
        public decimal Amount { get; set; }
        public DateTime DepositDate { get; set; }

        [MaxLength(100, ErrorMessage = "Comment is to long!")]
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
            var check = _withdrS.CheckIfWithdrawalIsPossible(accountId, Amount);
            if (ModelState.IsValid && check == true)
            {
                _withdrS.MakeAWithdral(accountId, Amount, Comment);
                _accountS.Update();
                return RedirectToPage("/CustomerInfo", new { custId = customerId });
            }
            return Page();


        }


    }
}
