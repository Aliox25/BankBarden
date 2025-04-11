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


        [Required(ErrorMessage = "Please enter a first name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter a last name")]
        public string LastName { get; set; }

        [Range(1, 99, ErrorMessage = "Please choose a valid gender")]
        public GenderE Gender { get; set; }
        public List<SelectListItem> Genders { get; set; }

        [Required(ErrorMessage = "Please enter a street address")]
        public string Streetaddress { get; set; }

        [Required(ErrorMessage = "Please enter a city")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please enter a zipcode that is 5 numbers long")]
        public string Zipcode { get; set; }

        [Range(1, 99, ErrorMessage = "Please choose a valid country")]
        public CountryE Country { get; set; }
        public List<SelectListItem> Countries { get; set; }

        public void OnGet()
        {
            Genders = _customerS.FillGenderlist();
            Countries = _customerS.FillCountrylist();
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
                    Zipcode
                );
                return RedirectToPage("/Customers");
            }
            Genders = _customerS.FillGenderlist();
            Countries = _customerS.FillCountrylist();
            return Page();
        }
    }
}
