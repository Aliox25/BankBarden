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
        public List<Account> GetAccounts(int custId)
        {
            return _dbContext.Accounts.Include(a => a.Dispositions).Where(a => a.Dispositions.Any(d => d.CustomerId == custId)).ToList();
        }

        public Account GetAccount(int accountId)
        {
            return _dbContext.Accounts.First(a => a.AccountId == accountId);
        }

        public void Update(Account account)
        {
            _dbContext.SaveChanges();
        }


    }
}
