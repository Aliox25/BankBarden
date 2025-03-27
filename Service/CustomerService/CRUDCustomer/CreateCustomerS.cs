using DataAccessLayer.DTOs;
using DataAccessLayer.Models;
using DataAccessLayer.Models.ENUM;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.CustomerService.CRUDCustomer
{
    public class CreateCustomerS : ICreateCustomerS
    {
        private readonly BankAppDataContext _dbContext;

        public CreateCustomerS(BankAppDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void CreateCustoms(string FN, string LN, GenderE GE, string SA, string C, Country CT, string PC)
        {
            var customerDTO = new Customer
            {
                Givenname = FN,
                Surname = LN,
                Gender = GE,
                Streetaddress = SA,
                City = C,
                Country = CT.Name,
                Zipcode = PC,
                CountryCode = CT.Code
            };

            _dbContext.Customers.Add(customerDTO);
            _dbContext.SaveChanges();
        }

    }
}
