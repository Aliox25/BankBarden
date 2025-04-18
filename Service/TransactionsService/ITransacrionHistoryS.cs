using DataAccessLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.TransactionsService
{
    public interface ITransacrionHistoryS
    {
        List<TransacrionHistoryDTO> GetAllTransactionHistory(int accountId);

    }
}
