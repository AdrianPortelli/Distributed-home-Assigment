using Google.Cloud.Firestore;
using MicroServiceThree.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroServiceThree.DataAccess
{
    public interface IFireStoreDataAccess
    {
        void createTransactionLog(Transactions transactions);
        Task<bool> depositfunds(string email, string bankaccountno, double funds);
        bool TranferFundsToSameOwner(string email, string backAccountNoWithdraw, string backAccountNoDeposit, double fundstodeposit);
        bool TranferFundsToDifferntOwner(string email, string emaildeposit, string backAccountNoWithdraw, string depositIBAN, double fundstodeposit);


    }
}
