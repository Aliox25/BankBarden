using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.TransactionsService
{
    public interface IWithdrawalS
    {
        void MakeAWithdral(int accountId, decimal amount, string comment);
    }
}
