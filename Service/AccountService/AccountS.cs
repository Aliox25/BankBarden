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

        public AccountDTO GetSingelAccount(int accountId)
        {
            var quarry = _dbContext.Accounts.First(a => a.AccountId == accountId);

            return new AccountDTO
            {
                Id = quarry.AccountId,
                Balance = quarry.Balance
            };
        }

        public void CreateAccount(int customerId, decimal balance, AccFrequencyE frequency)
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
                Type = "OWNER"
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

        public void Update()
        {
            _dbContext.SaveChanges();
        }


    }
}
