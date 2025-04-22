using AutoMapper;
using BankBarden.ViewModels;
using DataAccessLayer.Models.ENUM;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.AccountService;
using Service.CustomerService;

namespace BankBarden.Pages
{
    [ResponseCache(Duration = 30, VaryByQueryKeys = new[]{ "country" })]
    public class Top10CustomersModel : PageModel
    {
        private readonly IAllCustomerS _allCustS;
        private readonly IMapper _mapper;

        public Top10CustomersModel(IAllCustomerS allCustS, IMapper mapper)
        {
            _allCustS = allCustS;
            _mapper = mapper;
        }

        public List<AllCustomersViewModel> Customers { get; set; }
        public CountryE Country { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public void OnGet(CountryE country)
        {
            Country = country;

            Customers = new List<AllCustomersViewModel>();
            var cust = _allCustS.Get10Customer(Country);
            _mapper.Map(cust, Customers).ToList();

        }
    }
}
