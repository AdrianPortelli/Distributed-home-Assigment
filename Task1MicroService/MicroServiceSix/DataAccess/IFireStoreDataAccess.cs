using Google.Cloud.Firestore;
using MicroServiceSix.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroServiceSix.DataAccess
{
    public interface IFireStoreDataAccess
    {

        ExchangeRateModel getExchangeRate(string basecur, string symbol);
    }
}
