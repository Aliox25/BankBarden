using DataAccessLayer.DTOs;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.CustomerService
{
    public interface IAllCustomerS
    {
        string GetColumOrder(string colum);
        string GetSortOrder(string order);
        int GetPageNumber(int page);
        int GetMaxPage(string country, string quastion);
        List<AllCustomerDTO> GetCustomers(string country, string colum, string order, int page, string quastion);
        
    }
}
