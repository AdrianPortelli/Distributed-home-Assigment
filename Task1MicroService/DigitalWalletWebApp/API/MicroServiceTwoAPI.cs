using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using DigitalWalletWebApp.WebClient;


namespace MicroServiceSix.API
{
    public class MicroServiceTwoAPI
    {
        
      /*  private readonly string hostEndpoint = "https://api.apilayer.com/exchangerates_data";
        private readonly string lastestendpoint = "latest";*/



        private readonly webClient webclient = webClient.WebClientInstance;

        private static MicroServiceTwoAPI exchangeRateApi = null;

        private MicroServiceTwoAPI() { }


        public static MicroServiceTwoAPI ExchangeRateAPI
        {
            get
            {
                if(exchangeRateApi == null)
                {
                    exchangeRateApi = new MicroServiceTwoAPI();
                }
                return exchangeRateApi;
            }
        }



        private HttpRequestMessage GetRequestMessage(string hostEndpoint,string microServiceControllerName,string endpoint,string parameters) { 

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(hostEndpoint + "/api/v1/TaskTwo/"+ endpoint + "/"+ parameters),
                
            };

            return request;
        }



        // parsing request
    }
}
