using DataAccessLayer.DTOs;
using DataAccessLayer.Models;
using DataAccessLayer.Models.ENUM;
using Microsoft.AspNetCore.Mvc.Rendering;
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
         
        public List<SelectListItem> FillFrequencyList()
        {
            return Enum.GetValues<AccFrequencyE>().Select(e => new SelectListItem
            {
                Value = e.ToString(),
                Text = e.ToString()
            }).ToList();
        }

        public List<SelectListItem> FillAccoutnList(int custId)
        {
            var quarry = GetAccounts(custId)
                .Select(a => new SelectListItem
                {
                    Value = a.Id.ToString(),
                    Text = $"Account {a.Id} - Balance: {a.Balance}"
                });
            return quarry.ToList();
        }

        public AccountDTO GetSingelAccount(int accountId)
        {
            var quarry = _dbContext.Accounts.Include(d => d.Dispositions).First(a => a.AccountId == accountId);

            return new AccountDTO
            {
                Id = quarry.AccountId,
                Balance = quarry.Balance,
                Frequency = quarry.Frequency,
                AccountType = quarry.Dispositions.First().Type
            };
        }

        public void CreateAccount(int customerId, decimal balance, AccFrequencyE frequency, string accountType)
        {
            var customer = _dbContext.Customers
                .Include(c => c.Dispositions)
                .ThenInclude(c => c.Account)
                .First(c => c.CustomerId == customerId);

            var account = new Account
            {
                Balance = balance,
                Frequency = frequency,
                Created = DateOnly.FromDateTime(DateTime.Now)
            };

            _dbContext.Accounts.Add(account);

            customer.Dispositions.Add(new Disposition
            {
                AccountId = account.AccountId,
                Account = account,
                CustomerId = customer.CustomerId,
                Customer = customer,
                Type = accountType
            });

            Update();
        }

        public int GetTotalAccounts(int customerId)
        {
            var quarry = _dbContext
                .Dispositions
                .Include(a => a.Account)
                .Where(c => c.CustomerId == customerId).Count();
            return quarry;
        }
        public List<SelectListItem> FillAccoutnTypeList()
        {
            return new List<SelectListItem>
            {
                new SelectListItem { Value = "OWNER", Text = "Owner" },
                new SelectListItem { Value = "DISPONENT", Text = "Disponent" }
            };

        }

        public void DeleteAccount(int accountId)
        {
            var acc = _dbContext.Accounts
                .FirstOrDefault(a => a.AccountId == accountId);
            var desp = _dbContext.Dispositions
                .FirstOrDefault(a => a.AccountId == accountId);
            var tran = _dbContext.Transactions
                .Where(a => a.AccountId == accountId)
                .ToList();

            _dbContext.Dispositions.Remove(desp);
            _dbContext.Transactions.RemoveRange(tran);
            _dbContext.Accounts.Remove(acc);

            Update();
        }
        public void Update()
        {
            _dbContext.SaveChanges();
        }


    }
}
