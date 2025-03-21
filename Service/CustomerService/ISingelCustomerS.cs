using DataAccessLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.CustomerService
{
    public interface ISingelCustomerS
    {
        SingelCustomerDTO GetCustomer(int customerId);
    }
}
