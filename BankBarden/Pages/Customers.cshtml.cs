using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BankBarden.ViewModels;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace BankBarden.Pages
{
    public class CustomersModel : PageModel
    {
        private readonly BankAppDataContext _dbContext;


        public CustomersModel(BankAppDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<AllCustomersViewModel> Customers { get; set; }
        public string Country { get; set; }
        public void OnGet(string coun, string sortColumn, string sortOrder)
        {
            Country = coun;
            var quary = _dbContext.Customers
            .Select(c => new AllCustomersViewModel
            {
                Id = c.CustomerId,
                Name = c.Givenname,
                City = c.City,
                Country = c.Country
            });

            if (Country != null)
            {
                quary = _dbContext.Customers
                .Where(c => c.Country == Country)
                .Select(c => new AllCustomersViewModel
                {
                    Id = c.CustomerId,
                    Name = c.Givenname,
                    City = c.City,
                    Country = c.Country
                });

            }
            if (sortColumn != null && sortOrder != null)
            {
                if (sortColumn == "Id")
                    if (sortOrder == "asc")
                        quary = quary.OrderBy(c => c.Id);
                    else if (sortOrder == "desc")
                        quary = quary.OrderByDescending(c => c.Id);


                if (sortColumn == "Name")
                    if (sortOrder == "asc")
                        quary = quary.OrderBy(c => c.Name);
                    else if (sortOrder == "desc")
                        quary = quary.OrderByDescending(c => c.Name);

                if (sortColumn == "City")
                    if (sortOrder == "asc")
                        quary = quary.OrderBy(s => s.City);
                    else if (sortOrder == "desc")
                        quary = quary.OrderByDescending(s => s.City);
            }
            Customers = quary.ToList();
        }
    }
}
