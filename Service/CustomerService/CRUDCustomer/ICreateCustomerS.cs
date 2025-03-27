using DataAccessLayer.DTOs;
using DataAccessLayer.Models;
using DataAccessLayer.Models.ENUM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.CustomerService.CRUDCustomer
{
    public interface ICreateCustomerS
    {
        void CreateCustoms(string FN, string LN, GenderE GE, string SA, string C, Country CT, string PC);
    }
}
