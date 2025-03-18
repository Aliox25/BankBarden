using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BankBarden.ViewModels;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Microsoft.AspNetCore.Authorization;

namespace BankBarden.Pages
{
    [Authorize(Roles = "Cashier")]
    public class CustomersModel : PageModel
    {
        private readonly BankAppDataContext _dbContext;


        public CustomersModel(BankAppDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<AllCustomersViewModel> Customers { get; set; }
        public string Country { get; set; }
        public string Column { get; set; }
        public string Order { get; set; }
        public int CurrentPage { get; set; }
        public void OnGet(string coun, string sortColumn, string sortOrder, int pageNumb)
        {
            Country = coun;

            if (sortColumn == null)
                sortColumn = "Id";
            Column = sortColumn;

            if (sortOrder == null)
                sortOrder = "asc";
            Order = sortOrder;

            if (pageNumb == 0)
                pageNumb = 1;
            CurrentPage = pageNumb;

            
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
            
            Customers = quary.ToList();
        }
    }
}
