using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.TransactionsService
{
    public class WithdrawalS : IWithdrawalS
    {
        private readonly BankAppDataContext _dbContext;

        public WithdrawalS(BankAppDataContext dbContext)
        {
            _dbContext = dbContext;
        }


        public void MakeAWithdral(int accountId, decimal amount, string comment)
        {
            var dbAccount = _dbContext.Accounts.FirstOrDefault(a => a.AccountId == accountId);
            dbAccount.Balance -= amount;
        }

        public bool CheckIfWithdrawalIsPossible(int accountId, decimal amount)
        {
            var dbAccount = _dbContext.Accounts.FirstOrDefault(a => a.AccountId == accountId);
            if (dbAccount.Balance >= amount)
            {
                return true;
            }
            return false;
        }
    }
}
