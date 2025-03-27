using BankBarden.ViewModels;
using DataAccessLayer.Models;
using DataAccessLayer.Models.ENUM;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Service.CustomerService;
using Service.CustomerService.CRUDCustomer;
using System.ComponentModel.DataAnnotations;

namespace BankBarden.Pages.CustomerCRUD
{
    [BindProperties]
    public class CreateCustomerModel : PageModel
    {
        private readonly ICreateCustomerS _createCusS;
        private readonly ISingelCustomerS _customerS;


        public CreateCustomerModel(ICreateCustomerS createCusS, ISingelCustomerS customerS)
        {
            _createCusS = createCusS;
            _customerS = customerS;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Range(1, 99, ErrorMessage = "Please choose a valid gender!")]
        public GenderE Gender { get; set; }
        public List<SelectListItem> Genders { get; set; }

        public string Streetaddress { get; set; }
        public string City { get; set; }

        [RegularExpression(@"^\d{5}$", ErrorMessage = "Please enter a valid postcode!")]
        public string Postcode { get; set; }
        public string Country { get; set; }
        
        public void OnGet()
        {
            Genders = _customerS.Fillgenderlist();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _createCusS.CreateCustoms(
                    FirstName,
                    LastName,
                    Gender,
                    Streetaddress,
                    City,
                    Country,
                    Postcode
                );
                return RedirectToPage("/Customers");
            }
            Genders = _customerS.Fillgenderlist();
            return Page();
        }
    }
}
