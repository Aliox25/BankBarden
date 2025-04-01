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
    public class EditCustomerS : IEditCustomerS
    {
        private readonly BankAppDataContext _dbContext;
        private readonly ISingelCustomerS _singelCustomerS;
        public EditCustomerS(BankAppDataContext dbContext, ISingelCustomerS singelCustomerS)
        {
            _dbContext = dbContext;
            _singelCustomerS = singelCustomerS;
        }

        public CRUDCustomerDTO GetCustomerDTO(int custId)
        {
            var customerDTO = _dbContext.Customers.FirstOrDefault(c => c.CustomerId == custId);

            return new CRUDCustomerDTO()
            {
                FirstName = customerDTO.Givenname,
                LastName = customerDTO.Surname,
                Gender = customerDTO.Gender,
                Streetaddress = customerDTO.Streetaddress,
                City = customerDTO.City,
                Postcode = customerDTO.Zipcode,
                Country = customerDTO.Country,
            };


        }

        public void UpdateCustomer(int custId, string FN, string LN, GenderE GE, string SA, string C, CountryE CT, string PC)
        {
            var customerDB = _dbContext.Customers.FirstOrDefault(c => c.CustomerId == custId);
            customerDB.Givenname = FN;
            customerDB.Surname = LN;
            customerDB.Gender = GE;
            customerDB.Streetaddress = SA;
            customerDB.City = C;
            customerDB.Country = CT;
            customerDB.Zipcode = PC;
            customerDB.CountryCode = _singelCustomerS.GetCountryCode(CT);

            _dbContext.SaveChanges();
        }


    }
}
