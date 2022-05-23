using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using DigitalWalletWebApp.Models;
using DigitalWalletWebApp.WebClient;
using Newtonsoft.Json;

namespace DigitalWalletWebApp.API
{
    public class MicroServiceTwoAPI
    {
       private readonly webClient webclient = webClient.WebClientInstance;

        private static MicroServiceTwoAPI microServiceTwoAPI = null;

        private MicroServiceTwoAPI() { }


        public static MicroServiceTwoAPI microSerivceTwo
        {
            get
            {
                if(microServiceTwoAPI == null)
                {
                    microServiceTwoAPI = new MicroServiceTwoAPI();
                }
                return microServiceTwoAPI;
            }
        }



        private HttpRequestMessage GetRequestMessageCreateAccount(string hostEndpoint, string email, string BankAccoutNo, string Payee, string BankCode, string IBAN, string Country, string CurrencyCode, double OpeningBalance) { 

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(hostEndpoint + "/api/v1/TaskTwo/createfundaccount" + "/"+email+"/"+BankAccoutNo+"/"+Payee+"/"+BankCode+"/"+IBAN+"/"+Country+"/"+CurrencyCode+"/"+OpeningBalance),
                
            };

            return request;
        }

        private HttpRequestMessage GetRequestMessageTwoParameters(string hostEndpoint,string endpoint, string parameterOne, string paramterTwo)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(hostEndpoint + "/api/v1/TaskTwo/"+endpoint + "/" + parameterOne + "/" + paramterTwo)
            };

            return request;
        }

        private HttpRequestMessage GetRequestMessageListFundAccount(string hostEndpoint,string email)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(hostEndpoint + "/api/v1/TaskTwo/listfundaccount" + "/" + email)
            };

            return request;
        }




        public string createAccount(string hostEndpoint, string email, string BankAccoutNo, string Payee, string BankCode, string IBAN, string Country, string CurrencyCode, double OpeningBalance)
        {
            
            var request = GetRequestMessageCreateAccount(hostEndpoint, email, BankAccoutNo,  Payee,  BankCode, IBAN,Country,CurrencyCode,OpeningBalance);

            JsonDocument jsonDocument = webclient.Request(request).Result;

            JsonElement root = jsonDocument.RootElement;

            string status = null;

            if (root.TryGetProperty("Status", out JsonElement statusJson))
            {
                status = statusJson.GetString();
            }

            return status;
        }
        public List<FundAccount> getFundList(string hostEndpoint, string email)
        {

            List<FundAccount> fundAccounts = new List<FundAccount>();

            var request = GetRequestMessageListFundAccount(hostEndpoint, email);

            JsonDocument jsonDocument = webclient.Request(request).Result;

            JsonElement root = jsonDocument.RootElement;

            string test = "";
            using (var stream = new MemoryStream())
            {
                Utf8JsonWriter writer = new Utf8JsonWriter(stream, new JsonWriterOptions { Indented = true });
                root.WriteTo(writer);
                writer.Flush();
                test =  Encoding.UTF8.GetString(stream.ToArray());
            }
            
            /*      string status = null;
                  if (root.TryGetProperty("Status", out JsonElement statusJson))
                  {
                      status = statusJson.GetString();

                      if (status.Equals("Unsuccessful"))
                      {
                          return null;
                      }
                  }*/

            return JsonConvert.DeserializeObject<List<FundAccount>>(test);// not sure it works requires testing


        }

        public string disableFundAccount(string hostEndpoint, string email, string BankAccoutNo)
        {

            var request = GetRequestMessageTwoParameters(hostEndpoint, "disablefundaccount", email, BankAccoutNo);

            JsonDocument jsonDocument = webclient.Request(request).Result;

            JsonElement root = jsonDocument.RootElement;

            string status = null;

            if (root.TryGetProperty("Status", out JsonElement statusJson))
            {
                status = statusJson.GetString();
            }

            return status;
        }

        public FundAccount SearchAccount(string hostEndpoint, string email, string accountNo)
        {

            List<FundAccount> fundAccounts = new List<FundAccount>();

            var request = GetRequestMessageTwoParameters(hostEndpoint, "searchFundAccount", email,accountNo);

            JsonDocument jsonDocument = webclient.Request(request).Result;

            JsonElement root = jsonDocument.RootElement;

            string status = null;
            if (root.TryGetProperty("Status", out JsonElement statusJson))
            {
                status = statusJson.GetString();

                if (status.Equals("Unsuccessful"))
                {
                    return null;
                }
            }

            return JsonConvert.DeserializeObject<FundAccount>(root.GetString());// not sure it works requires testing

        }

        // parsing request
    }
}
