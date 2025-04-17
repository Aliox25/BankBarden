using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BankBarden.Pages
{
    [Authorize(Roles = "Admin")]
    public class EmployeesModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
