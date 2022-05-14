using Google.Cloud.Firestore;
using MicroServiceTwo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroServiceTwo.DataAccess
{
    public interface IFireStoreDataAccess
    {
        void AddFundAccount(User user, FundAccount fundAccount);

        Task<bool> DisableFundAccount(string email, string bankaccountno);

        Task<List<FundAccount>> GetFundAccounts(string email);

        Task<FundAccount> GetFundAccount(string email, string bankaccountno);

    }
}
