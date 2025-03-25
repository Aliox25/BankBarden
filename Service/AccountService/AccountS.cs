using DataAccessLayer.DTOs;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.AccountService
{
    public class AccountS : IAccountS
    {
        private readonly BankAppDataContext _dbContext;

        public AccountS(BankAppDataContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<AccountDTO> GetAccounts(int custId)
        {
            var quarry = _dbContext
                .Dispositions
                .Include(a => a.Account)
                .Where(c => c.CustomerId == custId)
                .Select(a => new AccountDTO
                {
                    Id = a.AccountId,
                    Balance = a.Account.Balance
                });

            return quarry.ToList();
        }

        public AccountDTO GetSingelAccount(int accountId)
        {
            var quarry = _dbContext.Accounts.First(a => a.AccountId == accountId);

            return new AccountDTO
            {
                Id = quarry.AccountId,
                Balance = quarry.Balance
            };
        }

        public void Update()
        {
            _dbContext.SaveChanges();
        }


    }
}
