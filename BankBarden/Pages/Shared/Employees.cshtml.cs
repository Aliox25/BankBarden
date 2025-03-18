using BankBarden.ViewModels;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

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
        }
    }
}
