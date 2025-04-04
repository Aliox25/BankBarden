using DataAccessLayer.DTOs;
using DataAccessLayer.Models;
using DataAccessLayer.Models.ENUM;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NuGet.Packaging.Signing;
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
        private readonly ISingelCustomerS _singelCustomerS;

        public CreateCustomerS(BankAppDataContext dbContext, ISingelCustomerS singelCustomerS)
        {
            _dbContext = dbContext;
            _singelCustomerS = singelCustomerS;
        }

        public void CreateCustoms(string FN, string LN, GenderE GE, string SA, string C, CountryE CT, string ZC)
        {
            var customerDTO = new Customer
            {
                Givenname = FN,
                Surname = LN,
                Gender = GE,
                Streetaddress = SA,
                City = C,
                Country = CT,
                Zipcode = ZC,
                CountryCode = _singelCustomerS.GetCountryCode(CT)
            };

            _dbContext.Customers.Add(customerDTO);
            _dbContext.SaveChanges();
        }


    }
}
