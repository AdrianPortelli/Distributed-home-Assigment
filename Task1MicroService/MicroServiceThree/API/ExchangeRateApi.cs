using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using MicroServiceThree.WebClient;

namespace MicroServiceThree.API
{
    public class ExchangeRateApi
    {

        private readonly string hostEndpoint = "https://api.apilayer.com/exchangerates_data";
        private readonly string lastestendpoint = "lastest";



        private readonly webClient webclient = webClient.WebClientInstance;

        private static ExchangeRateApi exchangeRateApi = null;

        private ExchangeRateApi() { }


        public static ExchangeRateApi ExchangeRateAPI
        {
            get
            {
                if(exchangeRateApi == null)
                {
                    exchangeRateApi = new ExchangeRateApi();
                }
                return exchangeRateApi;
            }
        }



        private HttpRequestMessage GetRequestMessage(string endpoint, string queryString)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(hostEndpoint + "/" + endpoint + "/" + queryString), // requires modifcation
            };
            return request;
        }

    }
}
