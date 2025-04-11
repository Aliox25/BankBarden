using DataAccessLayer.DTOs;
using DataAccessLayer.Models;
using DataAccessLayer.Models.ENUM;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.AccountService
{
    public interface IAccountS
    {
        List<AccountDTO> GetAccounts(int custId);
        List<SelectListItem> FillFrequencyList();
        void CreateAccount(int customerId, decimal balance, AccFrequencyE frequency);
        void Update();
        AccountDTO GetSingelAccount(int accountId);



    }
}
