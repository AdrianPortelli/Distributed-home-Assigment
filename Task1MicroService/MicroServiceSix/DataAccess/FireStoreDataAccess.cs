using Google.Cloud.Firestore;
using MicroServiceSix.API;
using MicroServiceSix.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroServiceSix.DataAccess
{
    public class FireStoreDataAccess : IFireStoreDataAccess
    {
        private FirestoreDb db { get; set; }
        private readonly ExchangeRateApi exchangeRateApi = ExchangeRateApi.ExchangeRateAPI;

        public FireStoreDataAccess(string project)
        {
            db = FirestoreDb.Create(project);
          
        }


        public ExchangeRateModel getExchangeRate(string basecur, string symbol)
        {
                        
            return exchangeRateApi.getCurrentRate(basecur, symbol);
            
        }




    }
}
