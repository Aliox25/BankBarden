using DataAccessLayer.Models.ENUM;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Service.AccountService;
using System.ComponentModel.DataAnnotations;

namespace BankBarden.Pages.AccountCRUD
{
    [BindProperties]
    public class CreateAccountModel : PageModel
    {
        private readonly IAccountS _accountS;

        public CreateAccountModel(IAccountS accountS)
        {
            _accountS = accountS;
        }

        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Please enter a start amount")]
        [Range(0, 10000, ErrorMessage = "Please enter a amount between 0 and 10k")]
        public decimal Balance { get; set; }

        [Range(1, 99, ErrorMessage = "Please choose a valid frequency option")]
        public AccFrequencyE Frequency { get; set; }
        public List<SelectListItem> Frequencies { get; set; }

        public string AccountType { get; set; }
        public List<SelectListItem> AccountTypes { get; set; }


        public void OnGet(int custumarId)
        {
            CustomerId = custumarId;
            Frequencies = _accountS.FillFrequencyList();
            AccountTypes = _accountS.FillAccoutnTypeList();
        }
        public IActionResult OnPost(int custumarId)
        {
            if (ModelState.IsValid)
            {
                _accountS.CreateAccount(custumarId, Balance, Frequency, AccountType);
                return RedirectToPage("/CustomerInfo", new { custId = custumarId });
            }
            Frequencies = _accountS.FillFrequencyList();
            return Page();
        }
    }
}
