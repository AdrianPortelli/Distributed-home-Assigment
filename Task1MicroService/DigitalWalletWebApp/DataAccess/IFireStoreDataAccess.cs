using DigitalWalletWebApp.Models;
using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalWalletWebApp.DataAccess
{
    public interface IFireStoreDataAccess
    {
        Task<LatestNew> getLatestNews(string email);
        Task<WriteResult> savePrefCurrecnies(string email, PrefSymbols prefSymbols);
        Task<PrefSymbols> getPrefCurrenies(string email);
        Task<ExchangeRateModel> getLatestRates(string email);

    }
}
