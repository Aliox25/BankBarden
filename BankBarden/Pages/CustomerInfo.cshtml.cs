using BankBarden.ViewModels;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BankBarden.Pages
{
    public class CustomerInfoModel : PageModel
    {
        private readonly BankAppDataContext _dbContext;

        public CustomerInfoModel(BankAppDataContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<CustomrtInfoViewmodel> Customer {  get; set; }
        public void OnGet()
        {

        }
    }
}
