using MicroServiceTask2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroServiceTask2.DataAccess
{
    public interface IFireStoreDataAccess
    {
        void AddFundAccount(User user, FundAccount fundAccount);

    }
}
