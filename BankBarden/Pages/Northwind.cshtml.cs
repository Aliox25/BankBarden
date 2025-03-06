using BankBarden.NorthwindData;
using BankBarden.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace BankBarden.Pages
{
    public class NorthwindModel : PageModel
    {
        private readonly NorthwindInclIdentityContext _dbContext;

        public NorthwindModel(NorthwindInclIdentityContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<SupplierViewModel> Suppliers { get; set; } = new List<SupplierViewModel>();

        public void OnGet()
        {
            Suppliers = _dbContext.Suppliers.Select(s => new SupplierViewModel
            {
                Id = s.SupplierId,
                CompanyName = s.CompanyName,
                Region = s.Region
            }).ToList();
        }
    }
}
