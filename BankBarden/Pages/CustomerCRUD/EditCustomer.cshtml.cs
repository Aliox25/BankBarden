using DataAccessLayer.Models.ENUM;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Service.CustomerService.CRUDCustomer;
using Service.CustomerService;
using System.ComponentModel.DataAnnotations;
using DataAccessLayer.Models;

namespace BankBarden.Pages.CustomerCRUD
{
    [BindProperties]
    public class EditCustomerModel : PageModel
    {
        private readonly IEditCustomerS _editCusS;
        private readonly ISingelCustomerS _customerS;


        public EditCustomerModel(IEditCustomerS editCusS, ISingelCustomerS customerS)
        {
            _editCusS = editCusS;
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

        [RegularExpression(@"^\d{5}$", ErrorMessage = "Please enter a postcode that is 5 numbers long")]
        public string Postcode { get; set; }

        [Range(1, 99, ErrorMessage = "Please choose a valid country")]
        public CountryE Country { get; set; }
        public List<SelectListItem> Countries { get; set; }

        public void OnGet(int custumarId)
        {
            Genders = _customerS.Fillgenderlist();
            Countries = _customerS.FillCountrylist();

            var customerDB = _editCusS.GetCustomerDTO(custumarId);
            FirstName = customerDB.FirstName;
            LastName = customerDB.LastName;
            Gender = customerDB.Gender;
            Streetaddress = customerDB.Streetaddress;
            City = customerDB.City;
            Postcode = customerDB.Postcode;
            Country = customerDB.Country;
        }

        public IActionResult OnPost(int custumarId)
        {
            if (ModelState.IsValid)
            {
                _editCusS.UpdateCustomer(
                    custumarId,
                    FirstName,
                    LastName,
                    Gender,
                    Streetaddress,
                    City,
                    Country,
                    Postcode
                );

                return RedirectToPage("/CustomerInfo", new { custId = custumarId });

            }
            Genders = _customerS.Fillgenderlist();
            Countries = _customerS.FillCountrylist();
            return Page();


        }




    }
}
