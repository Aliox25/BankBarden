using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BankBarden.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace BankBarden.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly BankAppDataContext _dbContext;


    public IndexModel(ILogger<IndexModel> logger, BankAppDataContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }

    public List<CountryViewModel> Countries { get; set; }
    public void OnGet()
    {
        Countries = _dbContext.Customers
            .Include(d => d.Dispositions)
            .ThenInclude(a => a.Account)
            .GroupBy(c => c.Country)
            .Select(c => new CountryViewModel
            {
                Country = c.Key,
                UserCount = c.Count(),
                CountryTotalMoney = c.Sum(c => c.Dispositions.Sum(d => d.Account.Balance))
            })
            .ToList();
    }
}
