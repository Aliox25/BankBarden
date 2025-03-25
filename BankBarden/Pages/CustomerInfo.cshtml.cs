using BankBarden.ViewModels;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Service.AccountService;
using Service.CustomerService;

namespace BankBarden.Pages
{
    [Authorize(Roles = "Cashier")]
    public class CustomerInfoModel : PageModel
    {
        private readonly IAccountS _accountS;
        private readonly ISingelCustomerS _singelCustomer;

        public CustomerInfoModel(IAccountS accountS, ISingelCustomerS singelCustomer)
        {
            _accountS = accountS;
            _singelCustomer = singelCustomer;
        }
        public CustomrtInfoViewmodel Customer {  get; set; }
        public List<AcountViewModel> Accounts { get; set; }
        public void OnGet(int custId)
        {
            var quary = _singelCustomer.GetCustomer(custId);

            Customer = new CustomrtInfoViewmodel
            {
                Id = quary.Id,
                FirstName = quary.FirstName,
                LastName = quary.LastName,
                Balance = quary.Balance,
            };

            Accounts = _accountS.GetAccounts(custId).Select(a => new AcountViewModel
            {
                Id = a.Id,
                Balance = a.Balance
            }).ToList();
        }
    }
}
