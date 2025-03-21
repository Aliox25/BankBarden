using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BankBarden.Pages.Transactions
{
    public class DepositModel : PageModel
    {
        public decimal Amount { get; set; }
        public DateTime DepositDate { get; set; }
        public string Comment { get; set; }

        public void OnGet(int accountId)
        {
            DepositDate = DateTime.Now.AddHours(1);
        }
    }

}
