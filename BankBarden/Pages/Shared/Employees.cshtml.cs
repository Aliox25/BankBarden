using BankBarden.ViewModels;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace BankBarden.Pages.Shared
{
    [Authorize(Roles = "Admin")]
    public class EmployeesModel : PageModel
    {

        private readonly BankAppDataContext _dbContext;

        public EmployeesModel(BankAppDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<EmployeeViewModule> employees { get; set; }
        public void OnGet()
        {

            //var quary = _dbContext.Users
            //.Include(u => u.UserName)
            //.Select(c => new EmployeeViewModule
            //{
            //    UserName = c.UserName,
            //    UserRoll = c.UserRoll

            //});

            //if (Country != null)
            //{
            //    quary = _dbContext.Customers
            //    .Where(c => c.Country == Country)
            //    .Select(c => new AllCustomersViewModel
            //    {
            //        Id = c.CustomerId,
            //        Name = c.Givenname,
            //        City = c.City,
            //        Country = c.Country
            //    });

            //}
            //if (sortColumn != null && sortOrder != null)
            //{
            //    if (sortColumn == "Id")
            //        if (sortOrder == "asc")
            //            quary = quary.OrderBy(c => c.Id);
            //        else if (sortOrder == "desc")
            //            quary = quary.OrderByDescending(c => c.Id);


            //    if (sortColumn == "Name")
            //        if (sortOrder == "asc")
            //            quary = quary.OrderBy(c => c.Name);
            //        else if (sortOrder == "desc")
            //            quary = quary.OrderByDescending(c => c.Name);

            //    if (sortColumn == "City")
            //        if (sortOrder == "asc")
            //            quary = quary.OrderBy(s => s.City);
            //        else if (sortOrder == "desc")
            //            quary = quary.OrderByDescending(s => s.City);
            //}
            //Customers = quary.ToList();
        }
    }
}
