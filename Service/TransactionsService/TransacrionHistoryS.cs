using DataAccessLayer.DTOs;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.TransactionsService
{
    public class TransacrionHistoryS : ITransacrionHistoryS
    {

        private readonly BankAppDataContext _dbContext;

        public TransacrionHistoryS(BankAppDataContext dbContext)
        {
            _dbContext = dbContext;
        }


        public List<TransacrionHistoryDTO> GetAllTransactionHistory(int accountId)
        {
            var quary = _dbContext.Transactions
                .Where(t => t.AccountId == accountId)
                .OrderByDescending(t => t.Date)
                .Select(t => new TransacrionHistoryDTO
                {
                    Id = t.TransactionId,
                    Date = t.Date,
                    Amount = t.Amount,
                    Balance = t.Balance,
                    Symbol = t.Symbol,
                });
            return quary.ToList();
        }
    }
}
