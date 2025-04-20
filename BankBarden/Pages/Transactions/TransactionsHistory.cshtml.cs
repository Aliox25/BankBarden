using BankBarden.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Service.TransactionsService;

namespace BankBarden.Pages.Transactions
{
    public class TransactionsHistoryModel : PageModel
    {
        private readonly ITransacrionHistoryS _transacrionHistoryS;
        public TransactionsHistoryModel(ITransacrionHistoryS transacrionHistoryS)
        {
            _transacrionHistoryS = transacrionHistoryS;
        }

        public int CustomerId { get; set; }
        public int AccountId { get; set; }
        public int RowCount { get; set; }
        //public List<TransacrionHistoryViewModel> TransHistList { get; set; }


        public void OnGet(int customerId, int accountId)
        {
            CustomerId = customerId;
            AccountId = accountId;

            //TransHistList = _transacrionHistoryS.GetAllTransactionHistory(AccountId)
                //.Select(t => new TransacrionHistoryViewModel
                // {
                //     Id = t.Id,
                //     Date = t.Date,
                //     Amount = t.Amount,
                //     Balance = t.Balance,
                //     Symbol = t.Symbol,
                // })
            //    .Take(RowCount)
            //    .ToList();
        }

        public IActionResult OnGetShowMore(int rowCount, int accountId)
        {
            rowCount += 10;
            var skippedRows = rowCount - 10;

            var TransHistList = _transacrionHistoryS.GetAllTransactionHistory(accountId)
                .Skip(skippedRows)
                .Take(10)
                .Select(t => new TransacrionHistoryViewModel
                {
                    Id = t.Id,
                    Date = t.Date,
                    Amount = t.Amount,
                    Balance = t.Balance,
                    Symbol = t.Symbol,
                }).ToList();

            return new JsonResult(new { rowCount, transHistList = TransHistList });
        }




    }
}
