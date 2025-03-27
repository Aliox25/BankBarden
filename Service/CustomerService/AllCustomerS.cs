using DataAccessLayer.DTOs;
using DataAccessLayer.Models;
using DataAccessLayer.Models.ENUM;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.CustomerService
{
    public class AllCustomerS : IAllCustomerS
    {
        private readonly BankAppDataContext _dbContext;

        public AllCustomerS(BankAppDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public string GetColumOrder(string colum)
        {
            if (colum == null)
                colum = "Id";
            return colum;
        }
        public string GetSortOrder(string order)
        {
            if (order == null)
                order = "asc";
            return order;
        }
        public int GetPageNumber(int page)
        {
            if (page == 0)
                page = 1;
            return page;
        }
        public int GetMaxPage(string country, string quastion)
        {
            var quary = _dbContext.Customers
            .Select(c => new AllCustomerDTO
            {
                Id = c.CustomerId,
                Name = c.Givenname,
                City = c.City,
                CountryName = c.Country
            });

            if (country != null)
            {
                quary = _dbContext.Customers
                .Where(c => c.Country == country)
                .Select(c => new AllCustomerDTO
                {
                    Id = c.CustomerId,
                    Name = c.Givenname,
                    City = c.City,
                    CountryName = c.Country
                });
            }

            if (!string.IsNullOrEmpty(quastion))
            {
                quary = quary.Where(c => c.Name.Contains(quastion) || c.City.Contains(quastion));
            }

            decimal count = (decimal)quary.Count() / 20;
            var MaxPage = 1;
            if (count > 0)
            {
                MaxPage = (int)Math.Ceiling(count);
            }

            return MaxPage;

        }
        public List<AllCustomerDTO> GetCustomers(string country, string colum, string order, int page, string quastion)
        {
            var quary = _dbContext.Customers
                .Select(c => new AllCustomerDTO
                {
                    Id = c.CustomerId,
                    Name = c.Givenname,
                    City = c.City,
                    CountryName = c.Country
                });

            if (country != null)
            {
                quary = _dbContext.Customers
                .Where(c => c.Country == country)
                .Select(c => new AllCustomerDTO
                {
                    Id = c.CustomerId,
                    Name = c.Givenname,
                    City = c.City,
                    CountryName = c.Country
                });
            }

            if (colum == "Id")
                if (order == "asc")
                    quary = quary.OrderBy(c => c.Id);
                else if (order == "desc")
                    quary = quary.OrderByDescending(c => c.Id);

            if (colum == "Name")
                if (order == "asc")
                    quary = quary.OrderBy(c => c.Name);
                else if (order == "desc")
                    quary = quary.OrderByDescending(c => c.Name);

            if (colum == "City")
                if (order == "asc")
                    quary = quary.OrderBy(s => s.City);
                else if (order == "desc")
                    quary = quary.OrderByDescending(s => s.City);

            if (!string.IsNullOrEmpty(quastion))
            {
                quary = quary.Where(c => c.Name.Contains(quastion) || c.City.Contains(quastion));
            }

            var amountPerPage = (page - 1) * 20;
            quary = quary.Skip(amountPerPage).Take(20);

            return quary.ToList();

        }


    }
}
