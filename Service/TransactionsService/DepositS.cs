using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.TransactionsService
{
    public class DepositS : IDepositS
    {
        private readonly BankAppDataContext _dbContext;

        public DepositS(BankAppDataContext dbContext)
        {
            _dbContext = dbContext;
        }


        public void MakeADeposit(int accountId, decimal amount, string comment)
        {
            var dbAccount = _dbContext.Accounts.FirstOrDefault(a => a.AccountId == accountId);
            dbAccount.Balance += amount;

            var transaction = new Transaction
            {
                AccountId = accountId,
                Amount = amount,
                Date = DateOnly.FromDateTime(DateTime.Now),
                Balance = dbAccount.Balance,
                Type = "Credit",
                Operation = "Deposit",
                Symbol = comment
            };
            _dbContext.Transactions.Add(transaction);
            _dbContext.SaveChanges();
        }
    }
}
