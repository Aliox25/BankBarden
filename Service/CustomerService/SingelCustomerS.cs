using DataAccessLayer.DTOs;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.CustomerService
{
    public class SingelCustomerS : ISingelCustomerS
    {
        private readonly BankAppDataContext _dbContext;

        public SingelCustomerS(BankAppDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public SingelCustomerDTO GetCustomer(int customerId)
        {
            var quary = _dbContext.Customers
                .Include(c => c.Dispositions)
                .ThenInclude(c => c.Account)
                .ThenInclude(c => c.Transactions)
                .FirstOrDefault(c => c.CustomerId == customerId);

            return new SingelCustomerDTO
            {
                Id = quary.CustomerId,
                FirstName = quary.Givenname,
                LastName = quary.Surname,
                Balance = quary.Dispositions.Select(d => d.Account.Transactions.Sum(t => t.Amount)).Sum()
            };

        }

    }
}
