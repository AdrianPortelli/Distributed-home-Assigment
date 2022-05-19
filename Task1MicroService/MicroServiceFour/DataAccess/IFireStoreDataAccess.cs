using MicroServiceFour.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroServiceFour.DataAccess
{
    public interface IFireStoreDataAccess
    {

        Task<List<Transactions>> getAllTranscations(string email);
        Task<List<Transactions>> getTranscationsForSpecificAccount(string email, string accountno);
        Task<List<Transactions>> GetTransactionsByDateRange(string email, DateTime start, DateTime end);
    }
}
