using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using DigitalWalletWebApp.Models;
using DigitalWalletWebApp.WebClient;
using Newtonsoft.Json;

namespace DigitalWalletWebApp.API
{
    public class MicroServiceThreeAPI
    {
       private readonly webClient webclient = webClient.WebClientInstance;

        private static MicroServiceThreeAPI microServiceThreeAPI = null;

        private MicroServiceThreeAPI() { }


        public static MicroServiceThreeAPI microserviceThreeAPI
        {
            get
            {
                if(microServiceThreeAPI == null)
                {
                    microServiceThreeAPI = new MicroServiceThreeAPI();
                }
                return microServiceThreeAPI;
            }
        }



        private HttpRequestMessage GetRequestMessageThreeParameters(string hostEndpoint, string endpoint, string parameterOne, string parameterTwo, double parameterThree) { 

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(hostEndpoint + "/api/v1/TaskThree/"+ endpoint + "/"+ parameterOne + "/"+ parameterTwo + "/"+ parameterThree),
                
            };

            return request;
        }

        private HttpRequestMessage GetRequestMessageFourParameters(string hostEndpoint,string endpoint, string parameterOne, string parameterTwo,string parameterThree, double paramterFour )
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(hostEndpoint + "/api/v1/TaskThree/"+endpoint + "/" + parameterOne + "/" + parameterTwo + "/"+parameterThree+"/"+paramterFour)
            };

            return request;
        }

        private HttpRequestMessage GetRequestMessageFiveParameters(string hostEndpoint, string endpoint, string parameterOne, string parameterTwo, string parameterThree, string parameterFour,double parameterFive)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(hostEndpoint + "/api/v1/TaskThree/" + endpoint + "/" + parameterOne + "/" + parameterTwo + "/" + parameterThree + "/" + parameterFour+"/"+parameterFive)
            };

            return request;
        }



        public string depositFunds(string hostEndpoint, string email, string BankAccoutNo, double funds)
        {

            var request = GetRequestMessageThreeParameters(hostEndpoint, "depositfunds", email, BankAccoutNo,funds);

            JsonDocument jsonDocument = webclient.Request(request).Result;

            JsonElement root = jsonDocument.RootElement;

            string status = null;

            if (root.TryGetProperty("Status", out JsonElement statusJson))
            {
                status = statusJson.GetString();
            }

            return status;
        }

        public string sameOwnerFundsTransfer(string hostEndpoint, string email, string DepositBankAccoutNo, string withdrawBackAccountNo,double funds)
        {

            var request = GetRequestMessageFourParameters(hostEndpoint, "sameownerfundtransfer", email, DepositBankAccoutNo, withdrawBackAccountNo, funds);

            JsonDocument jsonDocument = webclient.Request(request).Result;

            JsonElement root = jsonDocument.RootElement;

            string status = null;

            if (root.TryGetProperty("Status", out JsonElement statusJson))
            {
                status = statusJson.GetString();
            }

            return status;
        }

        public string differntOwnerFundTransfer(string hostEndpoint,string IBAN, string depositemail, string withdrawemail, string withdrawbankaccountno, double funds)
        {

            var request = GetRequestMessageFiveParameters(hostEndpoint, "differntownerfundtransfer", IBAN, depositemail, withdrawemail, withdrawbankaccountno,funds);

            JsonDocument jsonDocument = webclient.Request(request).Result;

            JsonElement root = jsonDocument.RootElement;

            string status = null;

            if (root.TryGetProperty("Status", out JsonElement statusJson))
            {
                status = statusJson.GetString();
            }

            return status;
        }


        // parsing request
    }
}
