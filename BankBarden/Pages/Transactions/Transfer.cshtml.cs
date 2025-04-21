using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Service.AccountService;
using Service.TransactionsService;
using System.ComponentModel.DataAnnotations;

namespace BankBarden.Pages.Transactions
{
    [BindProperties]
    public class TransferModel : PageModel
    {
        private readonly IAccountS _accountS;
        private readonly IDepositS _depositS;
        private readonly IWithdrawalS _withdrS;

        public TransferModel(IAccountS accountS, IDepositS depositS, IWithdrawalS withdrS)
        {
            _accountS = accountS;
            _depositS = depositS;
            _withdrS = withdrS;
        }

        public int AccountIdFrom { get; set; }

        public List<SelectListItem> AccountList { get; set; }
        public int AccountIdTo { get; set; }
        public int CustomerId { get; set; }
        public decimal Balance { get; set; }


        [Range(1, 5000, ErrorMessage = "Amount can only be between 1 and 5000")]
        public decimal Amount { get; set; }
        public DateTime TransferDate { get; set; }

        [MaxLength(50, ErrorMessage = "Comment is to long")]
        public string? Comment { get; set; }

        public void OnGet(int accountIdFrom, int customerId)
        {
            AccountList = _accountS.FillAccoutnList(customerId);
            TransferDate = DateTime.Now.AddHours(1);
            AccountIdFrom = accountIdFrom;
            CustomerId = customerId;
            Balance = _accountS.GetSingelAccount(accountIdFrom).Balance;
        }

        public IActionResult OnPost(int accountIdFrom, int accountIdTo, int customerId)
        {
            if (_accountS.GetSingelAccount(accountIdFrom).Balance < Amount)
            {
                ModelState.AddModelError("Amount", "You don't have that much money");
            }

            if (ModelState.IsValid)
            {
                _withdrS.MakeAWithdral(accountIdFrom, Amount, Comment);
                _depositS.MakeADeposit(accountIdTo, Amount, Comment);
                _accountS.Update();
                return RedirectToPage("/CustomerInfo", new { custId = customerId });
            }
            Balance = _accountS.GetSingelAccount(accountIdFrom).Balance;
            return Page();


        }
    }
}
