using DataAccessLayer.DTOs;
using DataAccessLayer.Models;
using DataAccessLayer.Models.ENUM;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.CountryService
{
    public class CountryS : ICountryS
    {
        private readonly BankAppDataContext _dbContext;

        public CountryS(BankAppDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<CountryDTO> GetCountrys()
        {
            return _dbContext.Customers
            .Include(d => d.Dispositions)
            .ThenInclude(a => a.Account)
            .GroupBy(c => c.Country)
            .Select(c => new CountryDTO
            {
                Country = (CountryE)Convert.ToInt32(c.Key),
                UserCount = c.Count(),
                CountryTotalMoney = c.Sum(c => c.Dispositions.Sum(d => d.Account.Balance))
            })
            .ToList();
        }
    }
}
