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
                .FirstOrDefault(c => c.CustomerId == customerId);

            var totalBalance = _dbContext.Dispositions
                .Where(d => d.CustomerId == customerId)
                .Select(d => d.Account).Sum(a => a.Balance);


            return new SingelCustomerDTO
            {
                Id = quary.CustomerId,
                FirstName = quary.Givenname,
                LastName = quary.Surname,
                Gender = quary.Gender,
                Streetaddress = quary.Streetaddress,
                City = quary.City,
                Zipcode = quary.Zipcode,
                Country = quary.Country,
                Balance = totalBalance
            };

        }


        public List<SelectListItem> Fillgenderlist()
        {
            return Enum.GetValues<GenderE>().Select(e => new SelectListItem
            {
                Value = e.ToString(),
                Text = e.ToString()
            }).ToList();

        }

        public List<SelectListItem> FillCountrylist()
        {
            return Enum.GetValues<CountryE>().Select(e => new SelectListItem
            {
                Value = e.ToString(),
                Text = e.ToString()
            }).ToList();

        }

        public string GetCountryCode(CountryE country)
        {
            var enumCode = Enum.GetName(typeof(CountryE), country);
            var countryCode = enumCode.Substring(0, 2).ToUpper();
            return countryCode;
        }
    }
}
