using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BankBarden.ViewModels;
using Microsoft.EntityFrameworkCore;
using Service.CountryService;

namespace BankBarden.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly ICountryS _countryS;


    public IndexModel(ILogger<IndexModel> logger, ICountryS countryS)
    {
        _logger = logger;
        _countryS = countryS;
    }

    public List<CountryViewModel> Countries { get; set; }
    public void OnGet()
    {
        Countries = _countryS.GetCountrys().Select(c => new CountryViewModel
        {
            Country = c.Country,
            UserCount = c.UserCount,
            CountryTotalMoney = c.CountryTotalMoney
        }).ToList();
    }
}
