using DataAccessLayer.DTOs;
using DataAccessLayer.Models.ENUM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.CustomerService.CRUDCustomer
{
    public interface IEditCustomerS
    {
        void UpdateCustomer(int custId, string FN, string LN, GenderE GE, string SA, string C, CountryE CT, string PC);
        CRUDCustomerDTO GetCustomerDTO(int custId);
        void SoftDeleteCustomer(int custId);

    }
}
