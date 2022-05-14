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
        Task<int> getbalance(string email, string backaccountno);
        Task<bool> depositfunds(string email, string bankaccountno, int funds);
     
    }
}
