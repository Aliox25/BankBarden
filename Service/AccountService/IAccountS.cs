using DataAccessLayer.DTOs;
using DataAccessLayer.Models;
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
        void Update();
        AccountDTO GetSingelAccount(int accountId);

    }
}
