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
        List<SelectListItem> FillAccoutnTypeList();
        List<SelectListItem> FillAccoutnList(int custId);
        void CreateAccount(int customerId, decimal balance, AccFrequencyE frequency, string accountType);
        void Update();
        AccountDTO GetSingelAccount(int accountId);

        int GetTotalAccounts(int customerId);

    }
}
